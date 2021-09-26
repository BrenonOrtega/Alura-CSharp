using System;
using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class BusStop
    {
        Queue<Passenger> Passengers { get; set; } = new();

        public void PassengerArrive(Passenger passenger)
        {
            System.Console.WriteLine("Bus {0} arrived at {1}", passenger, DateTime.Now);
            Passengers.Enqueue(passenger);
        }

        public void BusArrive(Bus bus)
        {
            System.Console.WriteLine("Bus {0} arrived at {1}", bus, DateTime.Now);
            while(Passengers.Count <= Bus.MAXIMUM_CAPACITY && Passengers.Count > 0)
                bus.Load(Passengers.Dequeue());
        }
    }
}