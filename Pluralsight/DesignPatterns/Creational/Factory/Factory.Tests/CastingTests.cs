using System;
using Factory.Application.Factories.Shipping;
using Factory.Application.Providers;
using Xunit;

namespace Factory.Tests
{
    public class CastingTests
    {
        [Fact]
        public void CastingAnInterface_ToItsActualType_ShouldWork()
        {
            var factory = new GlobalShippingProviderFactory();
            var provider = factory.CreateShippingProvider("");

            var type = provider.GetType();
            if(provider is GlobalShippingProvider castProvider)
            {
                Assert.Same(provider, castProvider);
                Assert.IsAssignableFrom<ShippingProvider>(castProvider);
            }
        }
    }
}