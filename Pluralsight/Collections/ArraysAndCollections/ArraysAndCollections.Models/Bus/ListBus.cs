using System.Collections;
using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class ListBus : BaseBus, IBus
    {
        private List<Passenger> _passengers = new List<Passenger>();

        protected override ICollection Passengers => _passengers;

        protected override void Add(Passenger passenger) => _passengers.Add(passenger);

        public void ArriveAt(string location)
        {
            location ??= string.Empty;
            var names = new LinkedList<string>();

            var landingPassengers = _passengers.RemoveAll(x =>
            {
                var willLand = location.ToLower().Equals(x?.Destination?.ToLower());
                
                if(willLand)
                    System.Console.WriteLine("Passenger {0} will land at {1}.", x.Name, x.Destination);

                return willLand;
            });

            System.Console.WriteLine($"{ landingPassengers } passengers have landed at { location }");
        }
    }
}