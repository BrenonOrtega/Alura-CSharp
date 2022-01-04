using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireCron.Shared.Models
{
    public class PaybillStatusConsult
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string Payer { get; set; }
        public bool Paid { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public TimeSpan ElapsedTime { get => DateTime.Now - CreatedAt; }

        public PaybillStatusConsult()
        {
            Id = "-1";
            Amount = -1;
            Payer = "";
            Paid = false;
            CreatedAt = DateTime.UnixEpoch;
        }

        public static readonly PaybillStatusConsult Empty = new PaybillStatusConsult();
    }
}