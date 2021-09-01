using MassTransit;
using Microsoft.Extensions.Hosting;
using static FireOnWheels.Shared.Messaging.MassTransitRabbitMqConstants;

namespace FireOnWheels.Notification.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<IOrderRegisteredEventConsumer>();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(RabbitMqUri, host =>
                            {
                                host.Password(Password);
                                host.Username(Username);
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    services.AddMassTransitHostedService();
                });
    }
}
