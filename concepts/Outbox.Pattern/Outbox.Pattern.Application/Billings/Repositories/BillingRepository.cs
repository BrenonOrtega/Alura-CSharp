using System;
using System.Threading.Tasks;
using Outbox.Pattern.Domain;
using System.Collections.Generic;
using Outbox.Pattern.Application.Shared;

namespace Outbox.Pattern.Application.Billings.Repositories
{
    public class BillingRepository : IRepository<Billing>
    {
        Dictionary<Guid, Billing> _billings = new Dictionary<Guid, Billing>();

        public async Task<Billing> GetByIdAsync<V>(V id) where V : IEquatable<V>, IComparable<V>
        {
            if (id is not Guid || Guid.TryParse(id.ToString(), out var billId) is false)
                return Billing.Empty;

            var exists = _billings.TryGetValue(billId, out var billing);

            if (exists)
                return billing;
            
            return Billing.Empty;
        }

        public Task<Response> SaveAsync(Billing model)
        {
            _billings.Add(model.Id, model);
            return Task.FromResult(Response.Success());
        }
    }
}