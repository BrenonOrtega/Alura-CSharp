using System;
using Factory.Application.Providers;

namespace Factory.Application.Factories
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