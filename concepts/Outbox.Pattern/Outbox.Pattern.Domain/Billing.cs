using System;

namespace Outbox.Pattern.Domain
{
    public class Billing
    {

        public Billing() {  }

        public Billing(Guid id, Customer customer, double amount, double discount)
        {
            Id = id;
            Amount = amount;
            Discount = discount;
        }

        public Guid  Id { get; set; }
        public Customer Customer { get; set; } = Customer.Empty;
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get => Amount; }
        public double Total { get => Amount - Discount; }
        public bool Paid { get; set; }
        
        public static readonly Billing Empty = new()
        {
            Id = Guid.Empty,
            Amount = -1,
            Discount = -1,
            Paid = false,
        };
    }
}
