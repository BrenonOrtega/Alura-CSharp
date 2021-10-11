using System;
using Factory.Application.Providers;

namespace Factory.Application.Factories
{
    public class ShippingProviderFactory
    {
        public static ShippingProvider Create(string country) => country?.ToLower() switch 
        {
            "brazil" => new CorreiosProvider(),
            "canada" => new CanadaShippingProvider(),
            _ => throw new NotImplementedException()
        };
    }
}