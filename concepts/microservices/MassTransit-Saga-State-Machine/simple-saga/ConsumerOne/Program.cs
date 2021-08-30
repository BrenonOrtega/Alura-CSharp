using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace ConsumerOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", true);
                    config.AddEnvironmentVariables();

                    if (args != null)
                        config.AddCommandLine(args);
                })
                .ConfigureLogging((ctx, logging) =>
                {
                    logging.AddSerilog(dispose: true);
                    logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<OrderConsumer>();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("localhost", "/", x =>
                            {
                                x.Password("admin");
                                x.Username("admin");
                            });


                            var assemblies = Assembly.GetEntryAssembly();
                            cfg.ReceiveEndpoint("order-sent", 
                                x => x.ConfigureConsumer(context, typeof(OrderConsumer)));
                        });
                    });

                    services.AddMassTransitHostedService();
                    services.AddHostedService<Worker>();
                });
        }
    }
}
