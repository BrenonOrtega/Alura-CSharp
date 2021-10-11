using System.Globalization;

namespace Factory.Application.Providers
{
    public class GlobalVipShippingProvider : ShippingProvider
    {
        public override double Fee => 0;

        protected override string ProviderName => "VIP-Global";

        protected override CultureInfo GetCulture() => CultureInfo.InvariantCulture;
    }
}