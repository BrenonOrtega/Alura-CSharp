using System;
using System.Threading.Tasks;
using Outbox.Pattern.Application.Shared;
using Outbox.Pattern.Domain;
using System.Runtime.CompilerServices;
using Outbox.Pattern.Application.Billings.Commands;

[assembly: InternalsVisibleTo("Outbox.Pattern.Tests")]
namespace Outbox.Pattern.Application.Billings
{
    internal class BillingService : IBillingService
    {
        private readonly IPublisher<CreateBillingCommand> _publisher;

        public BillingService(IPublisher<CreateBillingCommand> publisher)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public async Task<Response<Billing>> CreateBillingAsync(Guid id, Customer customer, double amount, double discount)
        {
            var billing = new Billing(id, customer, amount, discount);
            var command = new CreateBillingCommand()
            {
                Billing = billing,
            };

            var result = await _publisher.ProcessAsync(command);

            if (result.IsSuccess)
                return Response<Billing>.Success(billing);

            return Response<Billing>.Fail(result.Reason);
        }
    }
}