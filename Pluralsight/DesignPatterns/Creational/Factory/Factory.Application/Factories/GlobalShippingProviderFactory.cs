using System;
using Factory.Application.Providers;

namespace Factory.Application.Factories
{
    public class GlobalShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalVipShippingProvider();
        }
    }
}