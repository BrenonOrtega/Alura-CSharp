using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using static FireOnWheels.Shared.Messaging.MassTransitRabbitMqConstants;

namespace FireOnWheels.Registration.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configBuilder => configBuilder.AddCommandLine(args)
                        .AddEnvironmentVariables()
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                        .AddCommandLine(args))
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(new Uri(RabbitMqUri), host =>
                            {
                                host.Username(Username);
                                host.Password(Password);
                            });

                            cfg.ReceiveEndpoint(RegisterOderQueue, e =>
                            {
                                e.Consumer<MassTransitConsumer>();
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    services.AddMassTransitHostedService();
                    services.AddHostedService<Worker>();
                });
    }
}
