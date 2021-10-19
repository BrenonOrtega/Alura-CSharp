using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Models
{
    public interface IDynamoEntity
    {
        static string  TableName { get; }
        static List<KeySchemaElement> KeySchemaElements { get; }
        static List<AttributeDefinition> AttributeDefinitions { get; }
        static List<LocalSecondaryIndex> SecondaryIndexes { get; }
        static ProvisionedThroughput ProvisionedThroughput { get; }

    }
}