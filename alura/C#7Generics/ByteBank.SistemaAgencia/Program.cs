using System;
using System.Diagnostics;
using ByteBank.Modelos;
namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1,2,3,4,5,6,7,8};

            ContaCorrente[] contas = new ContaCorrente[] 
                { new (1,1), new(2,2), new(3,3), new(4,4), new(5,5), new (6,6), new(7,7), new (8,8), new (8,8), new (8,8), new (8,8) };

            System.Console.WriteLine("Foreach:");
            foreach(var conta in contas)
            {
                System.Console.WriteLine($"Agencia: {conta.Agencia}, Numero: {conta.Numero} ");
            }

            System.Console.WriteLine("usando for e Indexador");
            for (int i=contas.Length - 1 ; i != -1 ; i --)
            {
                System.Console.WriteLine(contas[i]);
            }

            ListaContaCorrentes listaContas = new();

            System.Console.WriteLine(GetTotalInMb(GC.GetTotalMemory(true)));
            var a = new Stopwatch();
            a.Start();
            
            for(var i=0; i<10000; i++)
                listaContas.Add(contas);

            a.Stop();
            System.Console.WriteLine(a.ElapsedMilliseconds);
            System.Console.WriteLine(GetTotalInMb(GC.GetTotalMemory(true)));

            string GetTotalInMb(long byteValue) => (byteValue/Math.Pow(2,20)).ToString();
        }
    }
}
