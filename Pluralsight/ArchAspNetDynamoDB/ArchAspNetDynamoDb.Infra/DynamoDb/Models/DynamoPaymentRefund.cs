using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using ArchAspNetDynamoDb.Domain.Models.Entities;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Models
{
    [DynamoDBTable(DynamoPaymentRefund.TABLE_NAME)]

    public class DynamoPaymentRefund : IDynamoEntity
    {
        public const string TABLE_NAME = "PaymentRefunds";
        public static string TableName => TABLE_NAME;

        [DynamoDBRangeKey]
        public string PaymentId { get; init; }

        [DynamoDBIgnore]
        private DateTime _paidOutDate;
        [DynamoDBHashKey]
        public DateTime PaidOutDate { get => _paidOutDate.Date; set => _paidOutDate = value.Date; }
        public decimal Amount { get; set; }
        public Person Payer { get; set; }

        public static List<KeySchemaElement> KeySchemaElements => new List<KeySchemaElement>()
        {
            new KeySchemaElement { AttributeName = nameof(PaidOutDate), KeyType = KeyType.HASH, },
            new KeySchemaElement { AttributeName = nameof(PaymentId), KeyType = KeyType.RANGE },
        };

        public static List<AttributeDefinition> AttributeDefinitions => new List<AttributeDefinition>()
        {
            new AttributeDefinition(nameof(PaymentId), ScalarAttributeType.S),
            new AttributeDefinition(nameof(PaidOutDate), ScalarAttributeType.S),
            new AttributeDefinition(nameof(Payer) + nameof(Person.Document), ScalarAttributeType.S)
        };

        public static List<LocalSecondaryIndex> SecondaryIndexes => new List<LocalSecondaryIndex>
        {
            new LocalSecondaryIndex()
            {
                IndexName = $"GET_BY_{ nameof(Payer).ToUpper() }_{ nameof(Person.Document).ToUpper() }",
                KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement(nameof(PaidOutDate), KeyType.HASH),
                    new KeySchemaElement(nameof(Payer) + nameof(Person.Document), KeyType.RANGE),
                },
                Projection = new Projection()
                {
                    ProjectionType = ProjectionType.ALL
                }
            }
        };

0        public static ProvisionedThroughput ProvisionedThroughput => new ProvisionedThroughput()
        {
            ReadCapacityUnits = 5,
            WriteCapacityUnits = 2
        };
    }
}