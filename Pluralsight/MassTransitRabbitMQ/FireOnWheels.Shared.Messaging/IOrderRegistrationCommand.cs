namespace FireOnWheels.Shared.Messaging
{
    public interface IOrderRegistrationCommand
    {
        int Id { get; set; }
        IOrder Order { get; set; }
    }
}