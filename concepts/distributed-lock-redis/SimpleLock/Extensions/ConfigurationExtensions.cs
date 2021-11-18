using System;
using DistributedLock.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleLock.Configuration;
using StackExchange.Redis;

namespace SimpleLock.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration config) =>
            services.Configure<RedLockConfiguration>(config.GetSection(nameof(RedLockConfiguration)))
                .AddSingleton(_ => RedLockCreator.GetRedLockFactory())
                .AddSingleton(_ => ConnectionMultiplexer.Connect(config.GetConnectionString(nameof(StackExchange.Redis))).GetDatabase())
                .AddDistributedRedisCache(x => x.Configuration = config.GetConnectionString(nameof(StackExchange.Redis)));
    }
}