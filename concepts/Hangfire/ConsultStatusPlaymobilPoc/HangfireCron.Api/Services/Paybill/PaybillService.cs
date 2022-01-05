using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangfireCron.Api.Handlers;
using HangfireCron.Shared;
using HangfireCron.Shared.Models;

namespace HangfireCron.Api.Services.Paybill
{
    class PaybillService : IPaybillService
    {
        private readonly PaybillConsultHandler _handler;
        private readonly IAsyncRepository<PaybillStatusConsult> _repo;

        public PaybillService(PaybillConsultHandler handler, IAsyncRepository<PaybillStatusConsult> repo)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Task<IEnumerable<PaybillStatusConsult>> GetAll()
        {
           return _repo.GetAll();
        }

        public Task<PaybillStatusConsult> GetPaybill(string id)
        {
            return _handler.HandleAsync(id);
        }
    }
}