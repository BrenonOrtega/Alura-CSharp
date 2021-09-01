using MassTransit;
using Microsoft.Extensions.Hosting;

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
                    var config = hostContext.Configuration;

                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<IOrderRegisteredEventConsumer>();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(config["MassTransit:RabbitMQ:Uri"], host =>
                            {
                                host.Username(config["MassTransit:RabbitMQ:Username"]);
                                host.Password(config["MassTransit:RabbitMQ:Password"]);
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    services.AddMassTransitHostedService();
                });
    }
}
