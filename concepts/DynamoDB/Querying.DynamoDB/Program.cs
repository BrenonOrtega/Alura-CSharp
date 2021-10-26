using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Querying.DynamoDB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(c => c.AddJsonFile("appsettings.json", true, true)).Build();
            var config = host.Services.GetRequiredService<IConfiguration>();
            var key = config["secret-key"];
            var id = config["secret-id"];

            var credentials = new BasicAWSCredentials(key, id);

            var dynamoDb = new AmazonDynamoDBClient(credentials, new AmazonDynamoDBConfig() { ServiceURL = "http://localhost:8000" });
            await QueryingUsingLowLevelApi(dynamoDb);
        }

        private static async Task QueryingUsingLowLevelApi(AmazonDynamoDBClient dynamoDb)
        {
            var tableName = "personTable";

            /*  var createTableRequest = new CreateTableRequest()
              {
                  TableName = tableName,
                  BillingMode = BillingMode.PAY_PER_REQUEST,
                  KeySchema = new List<KeySchemaElement>()
                  {
                      new KeySchemaElement("id", KeyType.HASH),
                      new KeySchemaElement("subId", KeyType.RANGE),
                  },
                  AttributeDefinitions = new List<AttributeDefinition>()
                  {
                      new AttributeDefinition("id", ScalarAttributeType.N),
                      new AttributeDefinition("subId", ScalarAttributeType.N),
                  },
                  ProvisionedThroughput = new ProvisionedThroughput(10, 14)
              };

              await dynamoDb.CreateTableAsync(createTableRequest); */

            var putResponse = await dynamoDb.PutItemAsync(tableName,
                new Dictionary<string, AttributeValue>
                {
                    { "id", new AttributeValue(){N="1"}},
                    { "subId",new AttributeValue{N="1"}},
                    { "Name", new AttributeValue("Brenon")},
                    { "Age", new AttributeValue("23")},
                    { "Balance", new AttributeValue("2000")},
                    { "Height", new AttributeValue("1,73")},
                });

            var queryResponse = await dynamoDb.QueryAsync(new QueryRequest(tableName)
            {
                KeyConditionExpression = "id = :id AND subId = :subId",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    { ":id", new AttributeValue() {N = "1"}},
                    { ":subId", new AttributeValue() {N = "1"}}
                }
            });

            var table = Table.LoadTable(dynamoDb, tableName);

            var documents = table.Query(new QueryOperationConfig()
            {
                KeyExpression = new Expression()
                {
                    ExpressionStatement = "id = :id AND subId = :subId",
                    ExpressionAttributeValues = new()
                    {
                        { ":id", 1 },
                        { ":subId", 1 }
                    }
                },
                /* Select = SelectValues.SpecificAttributes,
                AttributesToGet = new List<string> { "id", "subId", "Age" } */
                /* KeyExpression = new Expression()
                {
                    ExpressionStatement = "id = :id AND subId = :subId",
                    ExpressionAttributeValues = new() { { ":id", 1 }, { ":subId", 1 } }
                } */
            });

            var list = new List<string>();

            foreach (var item in await documents.GetRemainingAsync())
                list.Add(item.ToJsonPretty().Replace(@"\u0022", "\""));

            var documentFile = "queriedDocuments.json";
            var rawFile = "rawQueried.json";

            await File.WriteAllTextAsync(GetFilePath(documentFile), JsonSerializer.Serialize(list));
            await File.WriteAllTextAsync(GetFilePath(rawFile), JsonSerializer.Serialize(queryResponse.Items, new JsonSerializerOptions(){Encoder = }), Encoding.ASCII);
        }

        private static string GetFilePath(string fileName) => Path.Join(AppContext.BaseDirectory, fileName);
    }
}
