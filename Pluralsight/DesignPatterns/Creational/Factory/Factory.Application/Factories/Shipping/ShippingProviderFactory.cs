using Factory.Application.Providers.ShippingProviders;


namespace Factory.Application.Factories.ShippingProviders
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