using System.Globalization;

namespace Factory.Application.Providers.ShippingProviders
{
    public class CanadaShippingProvider : ShippingProvider
    {
        protected override string ProviderName => "Canada";
        private static CultureInfo _culture = new CultureInfo("en-CA");

        protected override CultureInfo GetCulture() => _culture;

        public override double Fee => 4L;
    }

}