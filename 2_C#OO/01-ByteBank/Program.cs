using System;

namespace _01_ByteBank 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Cliente Brenon = new Cliente("Brenon", cpf: 45459992800, profissao: "Programador Jr", telefone: 1128348021);
            Cliente Lan = new Cliente(nome:"Lan", cpf: 12345678900, "Chefe Pai", 1545459832);


            ContaCorrente ContaBrenon = new ContaCorrente(titular: Brenon, 28975, 339660);
            ContaCorrente ContaLan = new ContaCorrente(titular: Lan, 1234, 4567, 1000);


            ContaBrenon.Depositar(quantia: 1000);
            ContaLan.Transferir(200, ContaBrenon);


            ContaBrenon.Depositar(quantia: -50);
            ContaLan.Depositar(500);

            
            ContaBrenon.Sacar(500); 
            ContaLan.Transferir(-10, ContaBrenon);
            
            ContaBrenon.Transferir(-500, ContaLan); 
            ContaLan.Sacar(1000);
                
            
            ContaLan.Depositar(-300);
            ContaBrenon.Depositar(-500);

            Console.WriteLine("Saldo Brenon:" + ContaBrenon.Saldo.ToString() + "\nSaldo ContaLan" + ContaLan.Saldo.ToString());
        }
    }
}
