using System;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            delegate string myString;
            myString = Func<myString, string> a = x => x?.Invoke() ;

            var otherString = myString?.Invoke();

            System.Console.WriteLine(otherString);
        }
    }
}
