using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Storage;
using Hangfire.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HangfireCron.Infra.Extensions
{
    public static class HangfireExtensions
    {
        public static IServiceCollection AddRecurrentHangfireJob(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(x => 
            {
                x.UseRedisStorage(configuration.GetConnectionString(nameof(StackExchange.Redis)),
                    new RedisStorageOptions()
                    {
                        Db = configuration.GetValue<int>("Hangfire:RedisDatabase"),
                        Prefix = nameof(Hangfire),
                    })
                .UseRecommendedSerializerSettings()
                //.UseSerilogLogProvider()
                ;
            });

            services.AddHangfireServer();

            return services;
        }

    }
}