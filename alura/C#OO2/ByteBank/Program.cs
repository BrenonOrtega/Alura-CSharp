using System;
using ByteBank.Funcionarios;
namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var gerBoni = new BonificacaoManager();
            var carlos = new Funcionario();
            carlos.Salario = 2500;

            var Ferraz = new Diretor();
            Ferraz.Salario = 15000;

            Console.WriteLine($"Bonif Carlos= {carlos.GetBonificacao()} Ferraz bonif = {Ferraz.GetBonificacao()}");

            gerBoni.Registrar(carlos, Ferraz);


        }
    }
}
