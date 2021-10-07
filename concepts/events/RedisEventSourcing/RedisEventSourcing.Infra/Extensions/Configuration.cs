using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RedisEventSourcing.Infra.Extensions
{
    public static class Configuration
    {
        public static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration config)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = config["Redis:InstanceName"] ?? Assembly.GetEntryAssembly().GetName().Name;
                options.Configuration = config.GetConnectionString("Redis");

                options.ConfigurationOptions = new () 
                {   
                    DefaultDatabase = int.TryParse(config["Redis:Database"], out var database) ? database : 0,
                };
            });

            return services;
        }
    }
}