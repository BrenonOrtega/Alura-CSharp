using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
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
                var tableName = (string)entity.GetProperty(nameof(IDynamoEntity.TableName)).GetValue(null, null);
                var keySchema = (List<KeySchemaElement>)entity.GetProperty(nameof(IDynamoEntity.KeySchemaElements)).GetValue(null, null);
                var attributeDefinitions = (List<AttributeDefinition>)entity.GetProperty(nameof(IDynamoEntity.AttributeDefinitions)).GetValue(null, null);
                var localSecondaryIndexes = (List<LocalSecondaryIndex>)entity.GetProperty(nameof(IDynamoEntity.SecondaryIndexes)).GetValue(null, null);
                var globalSecondaryIndexes = (List<GlobalSecondaryIndex>)entity.GetProperty(nameof(IDynamoEntity.GlobalSecondaryIndexes)).GetValue(null, null);
                var provisionedThroughput = (ProvisionedThroughput)entity.GetProperty(nameof(IDynamoEntity.ProvisionedThroughput)).GetValue(null, null);
                
                if (tableRequest.TableNames.Contains(tableName) is false)
                    await _dynamoDb.CreateTableAsync(
                        new CreateTableRequest()
                        {
                            TableName = tableName,
                            KeySchema = keySchema,
                            AttributeDefinitions =attributeDefinitions,
                            LocalSecondaryIndexes = localSecondaryIndexes,
                            ProvisionedThroughput = provisionedThroughput,
                            GlobalSecondaryIndexes = globalSecondaryIndexes,
                    });
            }
        }
    }
}