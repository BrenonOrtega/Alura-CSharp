using Microsoft.Extensions.DependencyInjection;
using Outbox.Pattern.Application.Billings.Services;

namespace Outbox.Pattern.Application.Billings
{
    public static class BillingExtensions
    {
        public static IServiceCollection AddBilling(this IServiceCollection services)
        {
            services.AddScoped<IBillingService, BillingService>();

            return services;
        }
    }
}
