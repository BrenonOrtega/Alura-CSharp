using System;
using System.Collections.Generic;
using _01_ByteBank.data.Exceptions;
using _01_ByteBank.Tests;

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

            Log(ContaCorrente.Instantiations);

            Log("Saldo Brenon:" + ContaBrenon.Saldo +
                    "\nSaldo ContaLan:" + ContaLan.Saldo);

            try {
                MetodoErro();
            } catch (DivideByZeroException e) {
                Console.WriteLine($"Não divide por zero, cacete!\n {e.TargetSite}");
            }

            Log(ContaBrenon.Saldo);
            ContaBrenon.Depositar(20);
            Log($"Conta Brenon Saldo: {ContaBrenon.Saldo}");
            
            try { 
                var erro = new ContaCorrente(Brenon, 12, -10);
            } catch (SaldoInvalidoException e) {
                Log(e.Message );        
            }

            Log(ContaBrenon.Saldo);
            try{ContaBrenon.Sacar(-20);}
            catch(QuantiaInvalidaException e){
                Console.WriteLine(e);
            }
            Log(ContaBrenon.Saldo);
            ContaBrenon.Depositar(100);
            Log(ContaBrenon.Saldo);
            ContaBrenon.Depositar(200);
            Log(ContaBrenon.Saldo);
            try { ContaBrenon.Depositar(-200); }
            catch(QuantiaInvalidaException e){ Console.WriteLine(e); }
            Log(ContaBrenon.Saldo);
        }
        
        static void MetodoErro() => dividir(5,0);
        static double dividir(int dividendo, int divisor) =>  dividendo / divisor;
        static void Log(Object msg) => Console.WriteLine(msg);
    
    }
}