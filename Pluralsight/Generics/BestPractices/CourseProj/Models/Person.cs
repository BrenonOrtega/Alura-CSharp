namespace BestPractices.Variance
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person() { }

        public string FullName => $"{ FirstName } { LastName }";
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => FullName;
    }
}