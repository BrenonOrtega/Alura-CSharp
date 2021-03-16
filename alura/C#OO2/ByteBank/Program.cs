using System;
using ByteBank.Funcionarios;
namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var gerBoni = new BonificacaoManager();
            var carlos = new Auxiliar("4562315846");

            log($"O salário de carlos é {carlos.Salario}");

            var Ferraz = new Diretor("4562315846");

            Console.WriteLine(Ferraz.Renda);
            Console.WriteLine($"Bonif Carlos= {carlos.GetBonificacao()} Ferraz bonif = {Ferraz.GetBonificacao()}");

            Funcionario Leozin = new Desenvolvedor("6sdaf541das321");
            Funcionario gustavo = new Auxiliar("fsd3124132");
            Funcionario Brenon = new Diretor("454.599.928-00");

            var a = Leozin.GetBonificacao();
            gerBoni.Registrar(carlos, Ferraz, gustavo, Brenon);
            Console.WriteLine($"Bonificação do Léo é R${a}");
            Console.WriteLine($"Total {gerBoni.GetTotalBonificacoes()} + {a} = {gerBoni.GetTotalBonificacoes() + a}");


        }

        private static void log(Object msg) => Console.WriteLine(msg.ToString());
    }
}
