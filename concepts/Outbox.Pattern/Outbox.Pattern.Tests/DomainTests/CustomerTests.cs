using Xunit;
using Outbox.Pattern.Domain;
using FluentAssertions;
using System;
namespace Outbox.Pattern.Tests.DomainTests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_Empty_Should_Have_Empty_Fields()
        {
            // Given
            var customer = Customer.Empty;

            // Then
            customer.Should().Match<Customer>(x => 
                x.Document.Equals(string.Empty) 
                && x.Name.Equals(string.Empty) 
                && x.Surname.Equals(string.Empty)
                && x.Bills != null);
        }
    }
}