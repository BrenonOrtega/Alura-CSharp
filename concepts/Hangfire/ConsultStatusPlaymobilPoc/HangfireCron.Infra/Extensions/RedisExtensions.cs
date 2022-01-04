using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HangfireCron.Infra.Extensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedRedisCache(x => 
            {
                x.Configuration = configuration.GetConnectionString(nameof(StackExchange.Redis));
            });

            return services;
        }
    }
}