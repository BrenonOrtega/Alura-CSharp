using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RedisEventSourcing.Contracts.Handlers;
using RedisEventSourcing.Contracts.Subscribers;

namespace RedisEventSourcing.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddSubscribers<V>(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var eventHandler = provider.GetRequiredService<IDataChangedEventHandler<V>>();

            var subscribers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(type => type.GetInterface(nameof(IDataChangedEventSubscriber)) is null? false : true));
    
            foreach (var subscriber in subscribers)
            {
                var method = subscriber.GetMethod(nameof(IDataChangedEventSubscriber.ListenEventAsync));
                var instance = provider.GetRequiredService(subscriber);
                eventHandler.DataChanged += (Func<V, Task>) Delegate.CreateDelegate(typeof(Func<V, Task>), instance , method);
            }

            return services;
        }
    }
}