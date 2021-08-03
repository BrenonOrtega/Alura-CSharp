using System;
using System.Globalization;

namespace SecureClient
{
    public class AuthConfig
    {
        public string ResourceId { get; set; }

        public string ClientSecret { get; set; }

        public string Value { get; set; }

        public string Instance { get; set; }

        public string TenantId { get; set; }

        public string ClientId { get; set; }

        public string BaseAddress { get; set; }

        public string Authority { get => String.Format(CultureInfo.InvariantCulture, Instance, TenantId); }
    }
}