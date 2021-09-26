using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class Bus
    {
        public const int MAXIMUM_CAPACITY = 6;
        public Stack<Passenger> Passengers { get; set; } = new Stack<Passenger>();

        public void Load(Passenger passenger)
        {
            if (Passengers.Count < MAXIMUM_CAPACITY)
            {
                Passengers.Push(passenger);
                System.Console.WriteLine("Passenger {0} just boarded", passenger.Name);
            }
        }

        public void ArriveAtTerminus()
        {
            while (Passengers.Count > 0)
            {
                var p = Passengers.Pop();
                System.Console.WriteLine("Passenger {0} just landed.", p.Name);
            }
        }
    }
}