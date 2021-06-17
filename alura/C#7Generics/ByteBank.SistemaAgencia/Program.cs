using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1,2,3,4,5,6,7,8};

            ContaCorrente[] contas = new ContaCorrente[] {new (1,1), new(2,2), new(3,3), new(4,4), new(5,5) };

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



        }
    }
}
