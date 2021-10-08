using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace RedisEventSourcing.Infra.Extensions
{
    public static class Configuration
    {
        public static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Redis");
            var password = config["Redis:Password"];
            var defaultDatabase = int.TryParse(config["Redis:Database"], out var database) ? database : 0;
            var instanceName = config["Redis:InstanceName"] ?? Assembly.GetEntryAssembly().GetName().Name;

            services.AddStackExchangeRedisCache(opts =>
            {
                opts.ConfigurationOptions = new ConfigurationOptions()
                {
                    DefaultDatabase = defaultDatabase,
                    Password = password,
                    ConnectRetry = 4,
                    ConnectTimeout = 1000,
                };
                
                opts.ConfigurationOptions.EndPoints.Add(connectionString);

                opts.InstanceName = instanceName;
                opts.Configuration = connectionString;
            }); 

            return services;
        }
}
}