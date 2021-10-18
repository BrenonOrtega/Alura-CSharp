using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using ArchAspNetDynamoDb.Infra.Repositories;
using ArchAspNetDynamoDb.Domain.Repositories;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using System;
using Microsoft.Extensions.Hosting;
using ArchAspNetDynamoDb.Infra.DynamoDb.Initializers;
using System.Threading.Tasks;
using Amazon.Runtime;
using ArchAspNetDynamoDb.Infra.DynamoDb;
using Amazon.DynamoDBv2.DataModel;
using Amazon;

namespace ArchAspNetDynamoDb.Infra.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddDynamoDb(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions<DynamoDbOptions>("AWS");
            services
                .AddTransient<IDynamoDBContext, DynamoDBContext>()
                .AddTransient<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient(new AmazonDynamoDBConfig()
                {
                    RegionEndpoint = RegionEndpoint.USEast1,
                    ServiceURL = "http://localhost:8000",
                }))
                .AddAsyncInitializer<DynamoInitializer>()
                ;
            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services) =>
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddTransient<IRepository<PaymentRefund>, PaymentRefundRepository>()
            ;
        
        private static AWSOptions GetAwsOptions(IConfiguration config) =>
            new AWSOptions
            {
                Region = Amazon.RegionEndpoint.GetBySystemName(config["AWS:Region"]),
                Credentials = new Amazon.Runtime.BasicAWSCredentials(config["AWS:AccessKey"], config["AWS:SecretKey"]),
            };

        private static AmazonDynamoDBConfig GetDynamoDBConfig(IConfiguration config) => 
            new AmazonDynamoDBConfig()
            {   
                ServiceURL = config.GetConnectionString("DynamoDB"),
                RegionEndpoint = RegionEndpoint.GetBySystemName(config.GetValue<string>("AWS:Region")),
                
            };
    }
}