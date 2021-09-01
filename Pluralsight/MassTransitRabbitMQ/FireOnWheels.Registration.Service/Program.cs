using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;

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
                        .AddJsonFile("appsettings.json", optional: false)
                        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                        .AddCommandLine(args))
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;
                    
                    services.AddMassTransit(x =>
                    {
                        x.SetKebabCaseEndpointNameFormatter();

                        x.AddConsumer<OrderRegistrationConsumer>();
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
                    //services.AddHostedService<Worker>();
                });
    }
}
