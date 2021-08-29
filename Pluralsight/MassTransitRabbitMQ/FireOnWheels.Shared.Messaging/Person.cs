namespace FireOnWheels.Shared.Messaging
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public override string ToString() => $"Person {Name}, Address: {Address}, City {City}";
    }
}