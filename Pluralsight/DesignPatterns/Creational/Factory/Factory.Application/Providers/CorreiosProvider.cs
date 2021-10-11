using System.Globalization;

namespace Factory.Application.Providers
{
    public class CorreiosProvider : ShippingProvider
    {
        protected override string ProviderName => "Brasil";
        public override double Fee => 30L;

        private static CultureInfo _culture = new CultureInfo("pt-br");

        protected override CultureInfo GetCulture() => _culture;
    }
}