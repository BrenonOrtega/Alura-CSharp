using System;
using ByteBank.data.Funcionarios;
using ByteBank.data.SistemaInterno;
using ByteBank.data.Externo;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var sistema = new SistemaInterno();
            var gerBoni = new BonificacaoManager();
            var carlos = new Auxiliar("4562315846");
            dynamic Ferraz = new Diretor("4562315846", "abc");
            Funcionario Leozin = new Desenvolvedor("6sdaf541das321");
            Funcionario gustavo = new Auxiliar("fsd3124132");
            dynamic Brenon = new Diretor("454.599.928-00", "123");

            gerBoni.Registrar(carlos, Ferraz, Leozin, gustavo, Brenon);
            log(gerBoni.GetTotalBonificacoes());
            sistema.Logar(Brenon, "abc");
            sistema.Logar(Ferraz, "abc");
            sistema.Logar(Brenon, "123");
            log("");

            dynamic outroBanco = new ParceiroComercial("Itaú", "123");
            sistema.Logar(outroBanco, "123");
            sistema.Logar(outroBanco, "abc");

        }

        private static void log(Object msg) => Console.WriteLine(msg.ToString());
    }
}
