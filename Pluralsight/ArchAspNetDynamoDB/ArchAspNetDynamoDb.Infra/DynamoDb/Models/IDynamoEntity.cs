using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Models
{
    public interface IDynamoEntity
    {
        string TableName { get; }
        List<KeySchemaElement> KeySchemaElements { get; }
        List<AttributeDefinition> AttributeDefinitions { get; }
        ProvisionedThroughput ProvisionedThroughput { get; }

    }
}