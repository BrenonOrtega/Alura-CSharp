using System;
using BestPractices.Variance;

namespace BestPractices
{
    public class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "Covariance" };

            if (args?[0] is "IEnumerable")
                IEnumerableExample.Run(args);

            else
                ReflectionExamples.Run(args);
        }
    }
}