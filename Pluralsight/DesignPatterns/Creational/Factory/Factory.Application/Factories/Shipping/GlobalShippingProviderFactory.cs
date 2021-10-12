using Factory.Application.Providers.ShippingProviders;

namespace Factory.Application.Factories.ShippingProviders
{
    public class GlobalShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalShippingProvider();
        }
    }
}