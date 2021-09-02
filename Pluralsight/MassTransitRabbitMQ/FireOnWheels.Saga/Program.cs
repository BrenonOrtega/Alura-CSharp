using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using FireOnWheels.Saga.Components.Sagas;
using FireOnWheels.Saga.Components.StateMachines;

namespace FireOnWheels.Saga
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
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            x.SetKebabCaseEndpointNameFormatter();
                            x.AddSagaRepository<OrderSaga>().InMemoryRepository();

                            x.AddSagaStateMachine<OrderStateMachine, OrderSaga>();
                            cfg.Host(config["MassTransit:RabbitMq:Uri"], host =>
                            {
                                host.Username(config["MassTransit:RabbitMq:Username"]);
                                host.Password(config["MassTransit:RabbitMq:Password"]);
                            });

                            cfg.ConfigureEndpoints(context);
                        });

                        services.AddMassTransitHostedService();
                    });
                });
    }
}
