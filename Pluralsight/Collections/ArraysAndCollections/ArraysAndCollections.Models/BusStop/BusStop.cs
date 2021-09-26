using System;
using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class BusStop
    {
        Queue<Passenger> Passengers { get; set; } = new();

        public void PassengerArrive(Passenger passenger)
        {
            System.Console.WriteLine("passenger {0} arrived at {1}", passenger.Name, DateTime.Now);
            Passengers.Enqueue(passenger);
        }

        public void BusArrive(IBus bus)
        {
            System.Console.WriteLine("Bus arrived at stop at {0}", DateTime.Now);
            
            while(bus.CanBoard)
                bus.Load(Passengers.Dequeue());
        }
    }
}