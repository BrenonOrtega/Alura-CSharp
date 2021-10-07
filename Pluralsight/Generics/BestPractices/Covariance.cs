using System.Collections.Generic;

namespace BestPractices.Variance
{
    public class Covariance
    {
        public void Run()
        {
            var me = new Engineer("Mechatronics", "brenon", "ortega", 23);
            Person alsoMe = me;
            System.Console.WriteLine(me);
            System.Console.WriteLine(alsoMe);

            IEnumerable<object> list = new List<Person> { me, alsoMe };

            foreach (var item in list)
                System.Console.WriteLine(item);
        }
    }

    public record Engineer(string Specialization, string FirstName, string LastName, int Age)
        : Person(FirstName, LastName, Age)
    { }
}