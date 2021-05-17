using System;
using ByteBank.Modelos.Data;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente Brenon = new("Brenon", 4152156242, "Chefe pae");
            ContaCorrente conta = new(Brenon, 212, 101, 1);

            System.Console.WriteLine(conta);
        }
    }
}
