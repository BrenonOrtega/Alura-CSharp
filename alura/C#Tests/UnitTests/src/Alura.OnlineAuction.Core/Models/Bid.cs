using System;

namespace Alura.OnlineAuction.Core.Models
{
    public class Bid
    {
        public Interested Customer { get; set; }
        public decimal Value { get; }

        public Bid(Interested customer, decimal value)
        {
            Customer = customer;
            Value = value >= 0 ? value : throw new ArgumentException("Bid value should be greater than 0");
        }
    }
}