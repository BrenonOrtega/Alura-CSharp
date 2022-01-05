using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using HangfireCron.Api.Configurations;
using HangfireCron.Shared.Models;
using HangfireCron.Shared;
using Hangfire;
using System.Text.Json;
using System.Text;

namespace HangfireCron.Api.Handlers
{
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

        public async Task<PaybillStatusConsult> HandleAsync(string id)
        {
            var bill = await _repo.GetById(id);

            if (bill.Equals(PaybillStatusConsult.Empty) || bill is null)
                return bill;


            if (bill.Paid is false && bill.StillInConsultTime(_options.ConsultTimeInMinutes))
            {
                ReescheduleStatusConsult(id, bill);
            }

            if (bill.Paid || bill?.StillInConsultTime(_options.ConsultTimeInMinutes) is false)
            {
                await FinishStatusConsult(bill);
            }

            return bill;
        }

        private async Task FinishStatusConsult(PaybillStatusConsult? bill)
        {
            _logger.LogInformation("Stoping consult operation. Bill status is {billStatus}",
                $"{ (bill.Paid ? "" : "not")} { nameof(bill.Paid) }");

            var tasks = new List<Task>
                {
                    _repo.SaveAsync(bill),
                    _cache.SetAsync(bill.Id, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(bill)),
                        new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(40) })
                };

            if (bill.Paid is false)
                tasks.Add(UndoReserveAmountAsync(bill));

            await Task.WhenAll(tasks);
        }

        private void ReescheduleStatusConsult(string id, PaybillStatusConsult? bill)
        {
            _logger.LogInformation("Consult for paybill {id} reescheduled, {time} remaining before cancellation.", id, bill.ElapsedTime);
            BackgroundJob.Schedule<PaybillConsultHandler>(x => x.HandleAsync(id), _options.RetryConsultInterval);
        }

        private async Task UndoReserveAmountAsync(PaybillStatusConsult bill)
        {
            _logger.LogInformation("Undoing Amount Reserve for Paybill: {id}", bill?.Id);

            // OTher logic to undo reserve amount.
            // await _undoAmountReserveService.UndoReserve(bill);

            await Task.CompletedTask;
        }
    }
}
