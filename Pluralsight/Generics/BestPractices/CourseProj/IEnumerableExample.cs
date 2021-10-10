using BestPractices.Variance;

namespace BestPractices
{
    public class IEnumerableExample
    {
        public static void Run(string[] args)
        {
            //i'll just implement my own foreach here
            var repo = new GenericRepo<Person>();

            var enumerator = repo.List.GetEnumerator();

            var i = 0;

            while(true)
            {
                if(enumerator.MoveNext() is false)
                    break;

                enumerator.Current.FirstName = "Person" + ++i;
                System.Console.WriteLine(enumerator.Current.FullName);
            }
        }
    }
}