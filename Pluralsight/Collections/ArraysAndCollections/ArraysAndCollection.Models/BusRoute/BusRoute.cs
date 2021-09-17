using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysAndCollection.Models

{
    public class BusRoute
    {
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public ICollection<BusRoute> Serves { get; set; } = new List<BusRoute>();

        public BusRoute(string name, string origin, string destination, int distance)
        {
            this.Name = name;
            this.Origin = origin;
            this.Destination = destination;
            this.Distance = distance;
        }

        public void AddServedRoute(BusRoute route) => Serves.Add(route);

        public bool IsServed(string location) => Serves.Any(x => object.Equals(x.Destination, location) || object.Equals(x.Origin, location));

        public override string ToString() => $"{Name} - Origin: {Origin} - Destination:{Destination} - Distance:{Distance}" + "\nServes:" + string.Join(", ", Serves.Select(x => x.Name));

        public static BusRoute Null => NullObject;
        
        private static BusRoute NullObject = new("", "", "", -1);
    }
}
