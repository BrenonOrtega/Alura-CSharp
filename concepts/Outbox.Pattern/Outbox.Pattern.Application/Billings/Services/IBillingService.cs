using System;
using System.Threading.Tasks;
using Outbox.Pattern.Application.Shared;
using Outbox.Pattern.Domain;

namespace Outbox.Pattern.Application.Billings.Services
{
    public interface IBillingService
    {
        Task<Response<Billing>> CreateBillingAsync(Guid id, Customer customer, double amount, double discount);
        Task<Billing> GetBillAsync(Guid id);
    }
}