using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Models
{
    public abstract class PartitionedAndSorted<TPartitionKey, TSortKey> : IDynamoEntity
    {
        public abstract ProvisionedThroughput ProvisionedThroughput { get; }
        public abstract string TableName { get; }
        public abstract List<KeySchemaElement> KeySchemaElements { get; }
        public abstract List<AttributeDefinition> AttributeDefinitions { get; }
    }
}