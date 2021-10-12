using System.Globalization;

namespace Factory.Application.Providers
{
    public class GlobalShippingProvider : ShippingProvider
    {
        public override double Fee => 0;

        protected override string ProviderName => "VIP-Global";

        protected override CultureInfo GetCulture() => CultureInfo.InvariantCulture;

        public string Description => "I'm a vip property just to test";
    }
}