using System;

namespace ArraysAndCollection.Models
{
    public class BusRoute
    {
        private static BusRoute NullObject = new("", "" , "", -1);
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public BusRoute(string name, string origin, string destination, int distance)
        {
            this.Name = name;
            this.Origin = origin;
            this.Destination = destination;
            this.Distance = distance;
        }

        public static BusRoute Null => NullObject;
    }
}
