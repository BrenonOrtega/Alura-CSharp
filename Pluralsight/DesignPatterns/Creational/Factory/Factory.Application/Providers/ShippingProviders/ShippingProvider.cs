using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Factory.Application.Providers.ShippingProviders
{
    public abstract class ShippingProvider
    {
        protected abstract string ProviderName { get; }
        public abstract double Fee { get; }

        protected abstract CultureInfo GetCulture();
        public IFormatProvider Culture => GetCulture();

        public string CreateLabel<T>(T labable) => ProviderName + labable?.GetHashCode();

        public bool IsCalledFromGetFactoryMethod { get; set; }

    }
}