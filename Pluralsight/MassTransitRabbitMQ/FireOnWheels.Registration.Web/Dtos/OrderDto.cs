using System;
using FireOnWheels.Shared.Messaging;

namespace FireOnWheels.Registration.Web
{
    public class OrderDto : IOrder
    {
        public Guid Id { get; set; }
        public Person Sender { get; set; }
        public Person Receiver { get; set; }
        public int Weight { get; set; }
        public bool IsFragile { get; set; }
        public bool IsOversized { get; set; }
    }
}