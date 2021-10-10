namespace BestPractices.Variance
{
    public class Engineer : Person
    {
        public Engineer(string Specialization, string FirstName, string LastName, int Age)
            : base(FirstName, LastName)
        {
        }

        public int Age { get; set; }
    }
}