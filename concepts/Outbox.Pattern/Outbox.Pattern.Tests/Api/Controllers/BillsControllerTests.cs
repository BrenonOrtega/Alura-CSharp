using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Outbox.Pattern.Api.Controllers;
using Outbox.Pattern.Application.Billings.Services;
using Outbox.Pattern.Domain;
using Xunit;

namespace Outbox.Pattern.Tests.Api.Controllers
{
    public class BillsControllerTests
    {
        [Fact]
        public async Task When_Bill_Is_Not_Found_Should_Return_404_Not_Found_Result()
        {
            var service = Substitute.For<IBillingService>();
            var sut = new BillsController(service);

            service.GetBillAsync(default).ReturnsForAnyArgs(Billing.Empty);

            var response = await sut.GetBillAsync(Guid.NewGuid());

            response.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Existing_Billing_Response_Value_Should_Be_Valid_Billing()
        {
            var id = Guid.NewGuid();
            var expected = new Billing
            {
                Id = id,
                Discount = 0,
                Paid = false,
                Amount = 100,
                Customer = Customer.Empty,
            };

            var service = Substitute.For<IBillingService>();
            var sut = new BillsController(service);

            service.GetBillAsync(default)
                .ReturnsForAnyArgs(expected);

            var response = await sut.GetBillAsync(id);
            var okResult = (OkObjectResult)response;

            var actual = okResult.Value as Billing;

            actual.Should().BeEquivalentTo(expected);
        }
    }
}