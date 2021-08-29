using FireOnWheels.Shared.Messaging;

namespace FireOnWheels.Registration.Web.Dtos
{
    public class OrderRegistrationCommand : IOrderRegistrationCommand
    {
        public int Id { get; set; }
        public IOrder Order { get; set; }
    }
}