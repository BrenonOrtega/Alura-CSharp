using System.Collections;
using System.Collections.Generic;

namespace ArraysAndCollections.Models
{
    public class LinkedListBus : BaseBus
    {
        private LinkedList<Passenger> _passengers = new LinkedList<Passenger>();

        protected override void Add(Passenger passenger) => _passengers.AddLast(passenger);
        protected override ICollection Passengers => _passengers;

        public void ArriveAt(string location)
        {
            location ??= string.Empty;
            var currentNode = _passengers.First;
            do
            {
                var nextNode = currentNode.Next;
                var currentPassenger = currentNode.Value;
                
                if(location.ToLower().Equals(currentPassenger?.Destination?.ToLower()))
                {
                    _passengers.Remove(currentNode);
                    System.Console.WriteLine("passenger: {0} is landing.", currentPassenger.Name);
                }
                
                currentNode = nextNode;

            } while(currentNode is not null);
        }
    }
}