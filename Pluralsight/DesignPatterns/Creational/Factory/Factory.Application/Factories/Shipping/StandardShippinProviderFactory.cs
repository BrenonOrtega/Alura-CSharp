using System;
using Factory.Application.Providers.ShippingProviders;

namespace Factory.Application.Factories.ShippingProviders
{
    public class StandardShippingProviderFactory : ShippingProviderFactory
    {
        public ShippingProvider Create(string country) => country?.ToLower() switch
        {
            "brasil" => new CorreiosProvider(),
            "canada" => new CanadaShippingProvider(),
            _ => throw new NotImplementedException()
        };

        public override ShippingProvider CreateShippingProvider(string country) => Create(country);
    }
}