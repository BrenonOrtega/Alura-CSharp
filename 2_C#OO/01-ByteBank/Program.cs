using System;

namespace _01_ByteBank 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            ContaCorrente Brenon = new ContaCorrente(titular: "Brenon", 28975, 339660);
            Console.WriteLine(Brenon.ToString()  + Brenon.saldo.ToString());
        }
    }
}
