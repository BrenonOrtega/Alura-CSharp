namespace FireOnWheels.Shared.Messaging
{
    public interface IOrderRegisteredEvents : ICreatedAt
    {
        int OrderId { get; }
        IOrder Order { get; set; }
    }

    public interface ICreatedAt
    {
        System.DateTime CreatedAt { get; }
    }
}