using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;

namespace ArchAspNetDynamoDb.Infra
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureDynamoDb(this IServiceCollection services, IConfiguration config)
        {
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddDefaultAWSOptions(GetAwsOptions(config));
            
            return services;
        }

        private static AWSOptions GetAwsOptions(IConfiguration config) =>
            new AWSOptions
            {
                Region = Amazon.RegionEndpoint.GetBySystemName(config["AWS:Region"]),
                Credentials = new Amazon.Runtime.BasicAWSCredentials(config["AWS:AccessKey"], config["AWS:SecretKey"])
            };
    }
}