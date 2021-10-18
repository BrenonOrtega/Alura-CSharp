using System;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using ArchAspNetDynamoDb.Infra.DynamoDb.Models;
using Extensions.Hosting.AsyncInitialization;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Initializers
{
    public class DynamoInitializer : IAsyncInitializer
    {
        readonly IAmazonDynamoDB _dynamoDb;
        public DynamoInitializer(IAmazonDynamoDB amazonDynamoDB)
        {
            _dynamoDb = amazonDynamoDB;
            var a = _dynamoDb.Config.ServiceURL;
        }

        public async Task InitializeAsync()
        {
            var tableRequest = await _dynamoDb.ListTablesAsync();

            var entities = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(c => c.GetTypes().Where(type => type.IsAssignableTo(typeof(IDynamoEntity))
                    && type.IsInterface is false && type.IsAbstract is false));

            foreach (var entity in entities)
            {
                var dynamoEntity = Activator.CreateInstance(entity) as IDynamoEntity;

                if (tableRequest.TableNames.Contains(dynamoEntity.TableName) is false)
                    await _dynamoDb.CreateTableAsync(dynamoEntity.TableName, dynamoEntity.KeySchemaElements, dynamoEntity.AttributeDefinitions, dynamoEntity.ProvisionedThroughput);

            }
        }
    }
}