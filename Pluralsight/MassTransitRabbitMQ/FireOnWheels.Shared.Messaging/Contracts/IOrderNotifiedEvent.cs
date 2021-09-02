namespace FireOnWheels.Shared.Messaging
{
    public class IOrderNotifiedEvent 
    {
        public int Id { get; set; }
        public IOrder Order { get; set; }
    }
}