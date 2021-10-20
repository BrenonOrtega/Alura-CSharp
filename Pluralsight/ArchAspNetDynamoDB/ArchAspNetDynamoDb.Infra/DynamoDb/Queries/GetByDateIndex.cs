using System;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using ArchAspNetDynamoDb.Domain.Models.Entities;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Queries
{
    public class GetByDate : DynamoDBOperationConfig
    {
        public static GetByDate Create(DateTime date) =>
            new GetByDate()
            {
                IndexName = $"GET_BY_{ nameof(PaymentRefund.PaidOutDate).ToUpper() }",
                ConsistentRead = false,
                QueryFilter = new System.Collections.Generic.List<ScanCondition>()
                {
                    new ScanCondition(nameof(PaymentRefund.PaidOutDate), ScanOperator.LessThanOrEqual, date)
                },
            };
    }
}