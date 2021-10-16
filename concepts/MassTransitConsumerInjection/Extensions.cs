using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;

namespace MassTransitConsumerInjection
{
    public static class Extensions
    {
        public static IHostBuilder AddMassTransitServices(this IHostBuilder builder) => 
            builder.ConfigureServices((context, services) =>
                {
                    services.AddTransient<IPaymentRefundConsumer, PaymentRefundConsumer>();

                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();
                        x.UsingInMemory((context, busConfig) =>
                        {
                            x.AddConsumer<IPaymentRefundConsumer>();
                            busConfig.ConfigureEndpoints(context);
                        });
                    });
                    services.AddMassTransitHostedService();
                    services.AddHostedService<Worker>();
                });
    }
}