using System;
using Aula1.Arrays;
using Aulas.Lists;

namespace C_10Collections1
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute(AulasList.run);
        }

        static void Execute(Action a)
        {
            a();
        }

        static void PrintAll(object[] a) 
        {
            for(int i=0; i < a.Length; i++)
                System.Console.WriteLine(a[i]);   
        }

    }
     
}