using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RabbitMqCommon
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RabbitmqConfiguration>(config.GetSection(RabbitmqConfiguration.RabbitMQ));
            return services;
        }

        public static IConfigurationBuilder SetupStandardRabbitMQ(this IConfigurationBuilder builder)
        {
            var path = Path.Join(Directory.GetCurrentDirectory(), "StandardSettings.Json");
            builder.AddJsonFile(path, optional: false, reloadOnChange: true);

            return builder;
        }


        
    }
}
