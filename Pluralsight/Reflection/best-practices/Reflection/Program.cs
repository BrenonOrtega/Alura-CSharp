using System;
using System.Linq;
using System.Reflection;
using Reflection.Classes;
using BenchmarkDotNet.Running;
using Reflection.Delegates;

namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exercises.InstantiatingAlienWithPrivateConstructor();
            Exercises.GetPropertyPassedInMethodWithLambdaFunction();

            Exercises.InvokePropertyUsingPropertyName(args);
            var summary = BenchmarkRunner.Run<MydelegateBench>();
        }

    }
    public delegate void MyDelegate<T, V>(T model, Func<T, V> func);
}
