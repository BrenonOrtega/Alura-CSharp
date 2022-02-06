using System;

namespace Outbox.Pattern.Domain
{
    public class Billing
    {
        public Billing() => Customer = Customer.Empty;

        public Billing(Guid id, Customer customer, double amount, double discount)
        {
            Id = id;
            Amount = amount;
            Discount = discount;
        }

        public Guid Id { get; set; }
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

        public class Builder
        {
            private Billing _billing;
            public Builder Create(Customer customer) 
            {
                _billing = new Billing() { Id = Guid.NewGuid(), Customer = customer };
                return this;
            }

            public Builder AddAmount(double amount) 
            {
                _billing.Amount += amount;

                return this;
            }

            public Builder AddDiscount(double value) 
            {
                _billing.Discount += value;

                return this;
            }

            public Builder ChangeCustomer(Customer customer)
            {
                _billing.Customer = customer;

                return this;
            }

            public Billing Build()
            {
                var bill = _billing;
                _billing = default;
                
                return bill;
            }
        }
    }
}
