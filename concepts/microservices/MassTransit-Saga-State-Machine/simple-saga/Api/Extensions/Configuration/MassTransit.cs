using System;
using Api.Components;
using GreenPipes;
using MassTransit;
using MassTransit.Saga;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions.Configuration
{
    public static class MassTransit
    {
        public static IServiceCollection AddMassTransitWithRabbitMQ(this IServiceCollection services)
        {
            services.AddSingleton<ISagaRepository<OrderState>, InMemorySagaRepository<OrderState>>();
            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.AddSagaStateMachine<OrderStateMachine, OrderState>()
                    .InMemoryRepository();

                busConfiguration.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost","/", e =>  
                    {
                        e.Username("admin");
                        e.Password("admin");
                    });
                    config.ReceiveEndpoint("order-saga", endpoint =>
                    {
                        endpoint.UseMessageRetry(r => r.Interval(10, TimeSpan.FromMilliseconds(30)));
                        endpoint.UseInMemoryOutbox();
                        endpoint.ConfigureSaga<OrderState>(context, config => config.UseInMemoryOutbox());
                    });
                });
            });

            services.AddMassTransitHostedService(); 
            return services;
        }
    }
}