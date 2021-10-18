using System;
using ArchAspNetDynamoDb.Domain.Models.ValueObjects;

namespace ArchAspNetDynamoDb.Domain.Models.Entities
{
    public class PaymentRefund
    {
        public string PaymentId { get; init; }
        public DateTime PaidOutDate { get; set; }
        public decimal Amount { get; set; }
        public Person Payer { get; set; }
    }
}