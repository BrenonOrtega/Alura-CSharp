using System;

namespace ArchAspNetDynamoDb.Api.Models
{
    public class PaymentRefund
    {
        public string PaymentId { get; } = Guid.NewGuid().ToString();
        public DateTime PaidOutDate { get; set; } = new DateTime(2021, 10, new Random().Next(0, 30));
        public decimal Amount { get; set; }
        public Person Payer { get; set; }
    }
}