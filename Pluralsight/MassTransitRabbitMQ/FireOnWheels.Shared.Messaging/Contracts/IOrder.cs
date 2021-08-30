using System;

namespace FireOnWheels.Shared.Messaging
{
    public interface IOrder
    {
        Guid Id { get; set; }
        Person Sender { get; set; }
        Person Receiver { get; set; }

        int Weight { get; set; }
        bool IsFragile { get; set; }
        bool IsOversized { get; set; }

    }
}
