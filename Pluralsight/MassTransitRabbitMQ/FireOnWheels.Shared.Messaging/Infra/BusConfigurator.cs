using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using static FireOnWheels.Shared.Messaging.MassTransitRabbitMqConstants;

namespace FireOnWheels.Shared.Messaging.Infra
{
    public static class BusConfigurator 
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> configAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg => 
            {
                cfg.Host(new Uri(RabbitMqUri), host => 
                {
                    host.Username(Username);
                    host.Password(Password);
                });

                configAction?.Invoke(cfg);
            });
        }
    }
}