using Microsoft.Extensions.DependencyInjection;

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