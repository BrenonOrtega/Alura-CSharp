using System;
using System.Collections.Generic;
using Factory.Application.Factories;
using Factory.Application.Models;
using Factory.Application.Providers;
using Xunit;

namespace Factory.Tests
{
    public class StandardShippingProviderFactoryTests
    {
        [Theory]
        [InlineData("brasil")]
        [InlineData("canada")]
        public void PassingDiferentCountries_Should_Return_Distinct_ShippingProviders(string providerName)
        {
            /// Arrange
            var factory = new StandardShippingProviderFactory();
            var shippingProvider =  factory.CreateShippingProvider(providerName);
            var dummyOrder = new Order(providerName, new List<(double, int, string)>());

            /// Act
            var labelName = shippingProvider.CreateLabel(dummyOrder);
            
            /// Assert
            Assert.Contains(providerName, labelName.ToLower());
        }

        [Theory]
        [InlineData(typeof(CorreiosProvider), "brasil")]
        [InlineData(typeof(CanadaShippingProvider), "canada")]
        public void Passing_CountryNames_ShouldReturn_Correct_Provider(Type type, string providerName)
        {
            /// Arrange
            var shippingProvider = new StandardShippingProviderFactory().GetShippingProvider(providerName);
            
            /// Assert
            Assert.IsType(type, shippingProvider);
        }
    }
}