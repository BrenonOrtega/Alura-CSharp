using System;

namespace ExampleDomain
{
    public class RefundPayment : IEntity<string>
    {
        public string Id { get; set; }
        Guid PaymentId { get; set; }
        decimal Amount { get; set; }
        string BankslipBarcode { get; set; }
        DateTime ReceivedAt { get; set; }
    }
}