using System;
using FireOnWheels.Shared.Messaging;

namespace FireOnWheels.Registration.Web.Dtos
{
    public class OrderRegistrationCommand : IOrderRegistrationCommand
    {
        public int Id { get; set; } = new Random().Next(0, 150);
        public IOrder Order { get; set; }

        public OrderRegistrationCommand(IOrder order)
        {
            Order = order;
        }
    }
}