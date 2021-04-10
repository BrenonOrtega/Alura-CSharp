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

            try {
                ContaCorrente conta = new ContaCorrente(titular: Brenon, 1, 339660, -1000);
            } catch (SaldoInvalidoException e ) {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            } 

            ContaCorrente ContaBrenon = new ContaCorrente(titular: Brenon, 1, 339660, 1000);
            ContaCorrente ContaLan = new ContaCorrente(titular: Lan, 1234, 4567, 1000);

            Log(ContaCorrente.Instantiations);
            Log("Saldo Brenon:" + ContaBrenon.Saldo + "\n" +
                "Saldo ContaLan:" + ContaLan.Saldo);

            try {
                MetodoErro();
            } catch (DivideByZeroException e) {
                Console.WriteLine($"Não divide por zero, cacete!\n {e.TargetSite}");
            } finally {
                Log(ContaBrenon.Saldo);
            }

            ContaBrenon.Depositar(20);
            Log($"Conta Brenon Saldo: {ContaBrenon.Saldo}");
            
            try { 
                var erro = new ContaCorrente(Brenon, 12, -10);
            } catch (SaldoInvalidoException e) {
                Log(e);        
            } finally {
                Log(ContaBrenon.Saldo);
            }

            
            try{
                ContaBrenon.Sacar(8000);
            } catch(SaqueInvalidoException e) {
                Log(e);
                Log(ContaBrenon.Saldo);
                Wait();
            
            }catch(Exception e){
                Log(e);
                Wait();
            } finally {
                Log(ContaBrenon.Saldo);
            }
            
            ContaBrenon.Depositar(100);
            Log(ContaBrenon.Saldo);
            
            ContaBrenon.Depositar(200);
            Log(ContaBrenon.Saldo);

            try { 
                ContaBrenon.Depositar(-200); 
            } catch(SaqueInvalidoException e) { 
                Console.WriteLine(e); 
            } finally {
                Log(ContaBrenon);
            }

            Log("End");
        }
        
        static void MetodoErro() => dividir(5,0);
        static double dividir(int dividendo, int divisor) =>  dividendo / divisor;
        static void Log(Object msg) => Console.WriteLine(msg);
        static void Wait() => Console.ReadKey();
    
    }
}