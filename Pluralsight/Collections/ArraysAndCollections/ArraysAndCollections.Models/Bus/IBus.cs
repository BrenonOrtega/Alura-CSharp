namespace ArraysAndCollections.Models
{
    public interface IBus
    {
        bool CanBoard { get; }
        void Load(Passenger passenger);
    }
}