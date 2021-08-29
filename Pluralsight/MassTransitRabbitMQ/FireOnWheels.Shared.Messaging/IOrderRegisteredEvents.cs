namespace FireOnWheels.Shared.Messaging
{
    public interface IOrderRegisteredEvents
    {
        int OrderId { get; }
        IOrder Order { get; set; }
    }
}