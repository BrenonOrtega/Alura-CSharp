using System;

namespace _01_ByteBank 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Cliente Brenon = new Cliente("Brenon", cpf: 45459992800, profissao: "Programador Jr", telefone: 1128348021);
            Cliente Lan = new Cliente(nome:"Lan", cpf: 12345678900, "Chefe Pai", 1545459832);


            ContaCorrente ContaBrenon = new ContaCorrente(titular: Brenon, 1, 339660, -1000);
            ContaCorrente ContaLan = new ContaCorrente(titular: Lan, 1234, 4567, 1000);

            string msg = $"{ContaCorrente.Instantiations}";
            Console.WriteLine(msg);

            Console.WriteLine(
                "Saldo Brenon:" + ContaBrenon.Saldo.ToString() +
                "\nSaldo ContaLan" + ContaLan.Saldo.ToString()
            );
        }
    }
}
