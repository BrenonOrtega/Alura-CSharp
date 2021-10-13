using System;
using System.Collections.Generic;
using Factory.Application.Factories.CountryFactory;
using Factory.Application.Models;
using Xunit;
using FluentAssertions;
using System.Text.Json;

namespace Factory.Tests
{
    public class ShopingCartTests
    {
        [Theory]
        [InlineData(typeof(BrasilOrderFactory), "brasil", 5)]
        [InlineData(typeof(BrasilOrderFactory), "vip-global", 15)]
        public void CreatingInstances_OfAbstractFactoryShouldWork(Type type, string countryName, int orderCount)
        {
            //Given
            var countryOrderFactory = (ICountryOrderFactory)Activator.CreateInstance(type);
            var order = new Order(countryName, GetOrders(orderCount));

            var shoppingCart = new ShoppingCart(order, countryOrderFactory);
            //When

            var label = shoppingCart.Finalize();

            //Then
            label.ToLower().Should().Contain(countryName);
        }

        [Theory]
        [InlineData(typeof(BrasilOrderFactory), "brasil", 5)]
        [InlineData(typeof(BrasilOrderFactory), "vip-global", 15)]
        public void TestName(Type type, string countryName, int orderCount)
        {
            //Given
            var countryOrderFactory = (ICountryOrderFactory)Activator.CreateInstance(type);
            var order = new Order(countryName, GetOrders(orderCount));

            var shoppingCart = new ShoppingCart(order, countryOrderFactory);
            //When

            var summary = shoppingCart.OrderSummary ;
            var expected = JsonSerializer.Serialize(summary);

            //Then
            summary.Should().Be("ANY JSON, I'M JUST USING THIS TO DEBUG");
        }

        [Theory]
        [InlineData(typeof(BrasilOrderFactory), "brasil", 5)]
        [InlineData(typeof(CanadaOrderFactory), "vip-global", 15)]
        public void InvoicesShouldMatchCorrectType(Type type, string countryName, int orderCount)
        {
            //Given
            var countryOrderFactory = (ICountryOrderFactory)Activator.CreateInstance(type);
            var order = new Order(countryName, GetOrders(orderCount));

            var shoppingCart = new ShoppingCart(order, countryOrderFactory);
            //When

            var summaryType = shoppingCart.GetInvoice().GetType();
            var expected = countryOrderFactory.GetInvoice(order).GetType();

            //Then
            summaryType.Should().Be(expected);
        }

        private IEnumerable<(double, int, string)> GetOrders(int orderCount)
        {
            for (var i = 0; i <= orderCount; i++)
                yield return (i * 10, i, $"Item {i}");
        }
    }
}