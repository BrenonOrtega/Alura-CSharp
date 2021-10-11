using System;
using Factory.Application.Providers;

namespace Factory.Application.Factories
{
    public abstract class ShippingProviderFactory
    {
        public ShippingProvider GetShippingProvider(string country)
        {
            var provider = CreateShippingProvider(country);
            provider.IsCalledFromGetFactoryMethod = true;
            return provider;
        }

        public abstract ShippingProvider CreateShippingProvider(string country);
    }

    
}