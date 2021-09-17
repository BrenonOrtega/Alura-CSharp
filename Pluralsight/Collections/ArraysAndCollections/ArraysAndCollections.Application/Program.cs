using System;
using System.Linq;
using System.Reflection;

namespace ArraysAndCollections.Application
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //DynamicsExercise();
            RunExercises(args);
        }

        static void DynamicsExercise()
        {
            dynamic[] objs = { "Birb", "Spiwrow", "Crow", "lul ", 1 };

            for (int i = 0; i < objs.GetLength(0); i++)
                if (objs[i] is ValueType)
                    System.Console.WriteLine(++objs[i]);
                else
                    System.Console.WriteLine(objs[i]);
        }
    }
}
