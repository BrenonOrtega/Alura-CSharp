using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using ArchAspNetDynamoDb.Domain.Models.Entities;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Models
{
     [DynamoDBTable(DynamoPaymentRefund.TABLE_NAME)]

    public class DynamoPaymentRefund : PartitionedAndSorted<string, string>
    {
        public const string TABLE_NAME = "PaymentRefunds";
        public override string TableName => TABLE_NAME;
        
        [DynamoDBRangeKey]

        public string PaymentId { get; init; }
        [DynamoDBHashKey]
        public DateTime PaidOutDate { get; set; }
        public decimal Amount { get; set; }
        public Person Payer { get; set; }

        public override List<KeySchemaElement> KeySchemaElements => new List<KeySchemaElement>()
        {
            new KeySchemaElement { AttributeName = nameof(PaidOutDate), KeyType = KeyType.HASH },
            new KeySchemaElement { AttributeName = nameof(PaymentId), KeyType = KeyType.RANGE }//(nameof(PaymentId), Amazon.DynamoDBv2.KeyType.RANGE)
        };

        public override List<AttributeDefinition> AttributeDefinitions => new List<AttributeDefinition>()
        {
            new AttributeDefinition(nameof(PaymentId), ScalarAttributeType.S),
            new AttributeDefinition(nameof(PaidOutDate), ScalarAttributeType.S),
        };

        public override ProvisionedThroughput ProvisionedThroughput => new ProvisionedThroughput()
        {
            ReadCapacityUnits = 5,
            WriteCapacityUnits = 2
        };
    }
}