using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using HangfireCron.Shared.Models;
using HangfireCron.Shared;
using Hangfire;
using System.Text.Json;

namespace HangfireCron.Api
{
    public class CelcoinConsultOptions
    {
        private int _consultTime;
        public TimeSpan ConsultTimeInSeconds { get => TimeSpan.FromSeconds(_consultTime * 100); }
        public TimeSpan ConsultTimeInMinutes { get => TimeSpan.FromMinutes(_consultTime); }
        public TimeSpan ConsultTimeInHours { get => TimeSpan.FromHours(_consultTime / 60); }

        public TimeSpan RetryConsultInterval { get; set; } = TimeSpan.FromSeconds(1);

        public CelcoinConsultOptions()
        {
            _consultTime = 30;
        }
    }

    public class PaybillConsultHandler
    {
        private readonly IDistributedCache _cache;
        private readonly IAsyncRepository<PaybillStatusConsult> _repo;
        private readonly ILogger<PaybillConsultHandler> _logger;

        private readonly CelcoinConsultOptions _options = new CelcoinConsultOptions();

        public PaybillConsultHandler(IDistributedCache cache, IAsyncRepository<PaybillStatusConsult> repo, ILogger<PaybillConsultHandler> logger)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PaybillStatusConsult> Handle(string id)
        {
            var bill = await _repo.GetById(id);
            var billNotFound = bill.Equals(PaybillStatusConsult.Empty);

            if (billNotFound)
                return bill;

            if (bill.Paid is false && IsInConsultTime(bill))
            {
                _logger.LogInformation("Consult for paybill {id} will happen in another minute, {time} remaining before cancellation.", id, bill.ElapsedTime);
                BackgroundJob.Schedule<PaybillConsultHandler>(x => x.Handle(id), _options.RetryConsultInterval);
                
                return bill;
            }

            if(IsInConsultTime(bill) is false)
            {
                await Task.WhenAll(
                    _repo.SaveAsync(bill),
                    _cache.SetAsync(bill)
                );

                if(bill.Paid is false)
                {
                    _logger.LogInformation("Undoing Amount Reserve for Paybill: {id}", id);
                    //UndoReserveAmount(bill);

                }

                return bill;
            }
        }

            /* 
            if(bill.Equals(PaybillStatusConsult.Empty) is false || TimeSpan.FromMinutes(30) <= DateTime.Now - bill.CreatedAt)
            {
                _logger.LogWarning("Empty Paybill - there's no paybill for Id {id}", id);
                BackgroundJob.Schedule<PaybillConsultHandler>(x => x.Handle(id), TimeSpan.FromMinutes(1));
                return PaybillStatusConsult.Empty;
            }
            else 
            {
                var serializedBill = JsonSerializer.Serialize(bill);

                _logger.LogInformation("Found bill for id {id}. Bill Data: {bill}", id, serializedBill);

                await _cache.SetStringAsync(bill.Id, serializedBill);

                return bill;
            } */
        }

        private bool IsInConsultTime(PaybillStatusConsult bill)
        {
            return _options.ConsultTimeInMinutes <= bill.ElapsedTime;
        }
    }
}