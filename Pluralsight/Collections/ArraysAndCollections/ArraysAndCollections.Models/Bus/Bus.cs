using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class Bus
    {
        public const int MAXIMUM_CAPACITY = 6;
        public ICollection<Passenger> Passengers { get; set; } = new HashSet<Passenger>();

        public void Load(Passenger passenger)
        {
            if(Passengers.Count < MAXIMUM_CAPACITY)
                Passengers.Add(passenger);
        }

    }
}