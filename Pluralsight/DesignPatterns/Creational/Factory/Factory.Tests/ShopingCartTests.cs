using System;
using System.Collections.Generic;
using Factory.Application.Factories.CountryFactory;
using Factory.Application.Models;
using Xunit;
using FluentAssertions;

namespace Factory.Tests
{
    public class ShopingCartTests
    {
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

            var label = shoppingCart.Finalize();

            //Then
            label.ToLower().Should().Contain(countryName);
        }

        private IEnumerable<(double, int, string)> GetOrders(int orderCount)
        {
            while(true)
            {
                int i = 0; 
                i++;
                yield return (i * 100, i, $"item {i}");
            }
        }
    }
}