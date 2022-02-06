using Xunit;
using Outbox.Pattern.Application.Shared;
using Outbox.Pattern.Domain;
using Outbox.Pattern.Application.Billings.Commands;
using NSubstitute;
using System.Threading.Tasks;
using Outbox.Pattern.Application;
using Outbox.Pattern.Application.Billings.Services;
using System;

namespace Outbox.Pattern.Tests.ApplicationTests.Billings
{
    public class BillingServiceTests
    {
        [Fact]
        public async Task CreateBilling_Should_Publish_CreateBillingCommand()
        {
            var publisher = Substitute.For<IPublisher<CreateBillingCommand>>();
            var repository = Substitute.For<IRepository<Billing>>();
            publisher.ProcessAsync(default).ReturnsForAnyArgs(Response<CreateBillingCommand>.Fail("mocked"));
            var sut = new BillingService(repository, publisher);

            await sut.CreateBillingAsync(System.Guid.Empty, Customer.Empty, 10, 3);

            await publisher.Received().ProcessAsync(Arg.Any<CreateBillingCommand>());
        }

        [Fact]
        public async Task Given_BillingExists_Getting_Billing_Should_Return_Correct_Billing()
        {
            var expectedId = Guid.NewGuid();
            var publisher = Substitute.For<IPublisher<CreateBillingCommand>>();
            var repository = Substitute.For<IRepository<Billing>>();

            repository.GetByIdAsync<Guid>(Arg.Any<Guid>()).ReturnsForAnyArgs(new Billing() { Id = expectedId });       
            var sut = new BillingService(repository, publisher);

            var bill = await sut.GetBillAsync(expectedId);
            await publisher.Received().ProcessAsync(Arg.Any<CreateBillingCommand>());
        }
    }
}
