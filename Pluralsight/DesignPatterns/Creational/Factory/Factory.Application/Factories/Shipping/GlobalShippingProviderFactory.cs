using Factory.Application.Providers;

namespace Factory.Application.Factories.Shipping
{
    public class GlobalShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalShippingProvider();
        }
    }
}