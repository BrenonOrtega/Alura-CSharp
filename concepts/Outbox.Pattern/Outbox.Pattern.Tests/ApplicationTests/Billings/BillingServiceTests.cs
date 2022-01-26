using Xunit;
using Outbox.Pattern.Application.Billings;
using Outbox.Pattern.Application.Shared;
using Outbox.Pattern.Domain;
using Outbox.Pattern.Application.Billings.Commands;
using NSubstitute;
using System.Threading.Tasks;
using Outbox.Pattern.Application;

namespace Outbox.Pattern.Tests.ApplicationTests.Billings
{
    public class BillingServiceTests
    {
        [Fact]
        public async Task CreateBilling_Should_Publish_CreateBillingCommand()
        {
            IPublisher<CreateBillingCommand> publisher = Substitute.For<IPublisher<CreateBillingCommand>>();
            publisher.ProcessAsync(default).ReturnsForAnyArgs(Response<CreateBillingCommand>.Fail("mocked"));
            var sut = new BillingService(publisher);

            await sut.CreateBillingAsync(System.Guid.Empty, Customer.Empty, 10, 3);

            await publisher.Received().ProcessAsync(Arg.Any<CreateBillingCommand>());
        }
    }
}