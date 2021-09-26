using System.Collections;

namespace ArraysAndCollections.Models
{
    public abstract class BaseBus : IBus
    {
        public const int MAXIMUM_CAPACITY = 12;
        protected abstract ICollection Passengers { get; }

        protected abstract void Add(Passenger passenger);

        public bool CanBoard => Passengers.Count <= MAXIMUM_CAPACITY;

        public void Load(Passenger passenger)
        {
            if (CanBoard)
            {
                Add(passenger);
                System.Console.WriteLine("Passenger {0} just boarded", passenger.Name);
            }
            else
                System.Console.WriteLine("No more passengers can board");
        }
    }
}