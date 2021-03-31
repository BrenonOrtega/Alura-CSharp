using System;
using System.Collections.Generic;

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
                "Saldo Brenon:" + ContaBrenon.Saldo +
                "\nSaldo ContaLan" + ContaLan.Saldo
            );

            try 
            {
                MetodoErro();
            } 
            catch (DivideByZeroException e) {
                Console.WriteLine($"Não divide por zero, cacete!\n {e.TargetSite}");
            }
            catch(Exception e) {
                Console.Write($@"{e.StackTrace}
                {e.Message} 
                {e.TargetSite}");
            }

            Log(ContaBrenon.Saldo);
            ContaBrenon.Depositar(20);
            Log($"Conta Brenon Saldo: {ContaBrenon.Saldo}");
            
            try { dynamic erro = new ContaCorrente(Brenon, 0,0);
            } catch (ArgumentException e) {
                Log(e.Message + "\n" + e.ParamName);
            }
        }

        static void MetodoErro(){
            dividir(5,0);
        }

        static double dividir(int dividendo, int divisor) {
            
            return  dividendo / divisor;
        }

        static void Log(object msg) => Console.WriteLine(msg);
    }
}
