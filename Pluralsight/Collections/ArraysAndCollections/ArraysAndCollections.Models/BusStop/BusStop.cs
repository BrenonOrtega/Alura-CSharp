using System;
using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class BusStop
    {
        Queue<Passenger> Passengers { get; set; }

        public void PassengerArrive(Passenger passenger)
        {
            Passengers.Enqueue(passenger);
        }

        public void BusArrive(Bus bus)
        {
            System.Console.WriteLine("Bus {bus} arrived at {Date}", bus, DateTime.Now);
            while(Passengers.Count <= Bus.MAXIMUM_CAPACITY || Passengers.Count < 0)
                bus.Load(Passengers.Dequeue());
        }
    }
}