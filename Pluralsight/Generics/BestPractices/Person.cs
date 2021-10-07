namespace BestPractices
{
    public record Person(string FirstName, string LastName, int Age)
    {
        public string Greet => "hello";
    }
}