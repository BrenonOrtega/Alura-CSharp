using Amazon.DynamoDBv2;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DynamoInfra
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureDynamoDB(this IServiceCollection services)
        {
            services.AddAWSService<IAmazonDynamoDB>();

            return services;
        }
    }
}