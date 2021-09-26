using System.Collections;
using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class Bus : BaseBus
    {
        private Stack<Passenger> _passengers = new Stack<Passenger>();
        protected override ICollection Passengers { get => _passengers; }
        protected override void Add(Passenger passenger) => _passengers.Push(passenger);

        public void ArriveAtTerminus()
        {
            while (_passengers.Count > 0)
            {
                var p = _passengers.Pop();
                System.Console.WriteLine("Passenger {0} just landed.", p.Name);
            }
        }
    }
}