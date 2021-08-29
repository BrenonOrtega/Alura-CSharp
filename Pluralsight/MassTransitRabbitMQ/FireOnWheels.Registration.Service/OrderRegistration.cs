using FireOnWheels.Shared.Messaging;

namespace FireOnWheels.Registration.Service
{
    public class OrderRegistration : IOrderRegistrationCommand
    {
        public int Id { get; set; }
        public IOrder Order { get; set; }
    }
}