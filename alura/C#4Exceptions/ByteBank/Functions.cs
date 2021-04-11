using System;

namespace _01_ByteBank.Functions
{
    public static class F {
        public static void MetodoErro() => dividir(5,0);
        public static double dividir(int dividendo, int divisor) =>  dividendo / divisor;
        public static void Log(Object msg) => Console.WriteLine(msg + "\n");
        public static void Wait() => Console.ReadKey();
        public static void LogStars() => Console.WriteLine("********************************************************************************************************"); 
    }
}