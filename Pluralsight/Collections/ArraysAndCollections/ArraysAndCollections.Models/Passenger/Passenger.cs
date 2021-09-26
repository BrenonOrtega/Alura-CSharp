namespace ArraysAndCollections.Models
{
    public class Passenger
    {
        public string Name { get; set; }
        public string Destination { get; set; }

        public Passenger(string name, string destination)
        {
            Name = name;
            Destination = destination ?? throw new System.ArgumentNullException(nameof(destination));
        }
    }
}