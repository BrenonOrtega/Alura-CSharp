using System;
using FluentAssertions;
using Outbox.Pattern.Domain;
using Xunit;

namespace Outbox.Pattern.Tests.DomainTests
{
    public class BillingsTests
    {
        [Fact]
        public void Default_Customer_Should_Be_Customer_Empty()
        {
            // Given
            var billing = new Billing();

            // Then
            billing.Customer.Should().Be(Customer.Empty);
        }

        [Theory]
        [InlineData(20, 3, 17)]
        [InlineData(35.3, 7, 28.3)]
        [InlineData(17, 0.75, 16.25)]
        public void Billing_Total_Values_Should_Match(double amount, double discount, double expected)
        {
            var billing = new Billing(Guid.Empty, Customer.Empty, amount, discount);

            billing.Total.Should().BeApproximately(expected, 0.00001);
            billing.SubTotal.Should().Be(amount);
            billing.Discount.Should().Be(discount);
        }
    }
}