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

            Log("Teste Setando Valor Negativo no saldo.");
            try {
                ContaCorrente conta = new ContaCorrente(titular: Brenon, 1, 339660, -1000);
            } catch (SaldoInvalidoException e ) {
                Log(e.Message);
            }
            LogStars();

            ContaCorrente ContaBrenon = new ContaCorrente(titular: Brenon, 1, 339660, 1000);
            ContaCorrente ContaLan = new ContaCorrente(titular: Lan, 1234, 4567, 1000);

            Log(ContaCorrente.Instantiations);
            Log("Saldo Brenon:" + ContaBrenon.Saldo + "\n" +
                "Saldo ContaLan:" + ContaLan.Saldo);

            Log("Exceção de dividir por zero.");
            try {
                MetodoErro();
            } catch (DivideByZeroException e) {
                Console.WriteLine($"Não divide por zero, cacete!\n {e.TargetSite}");
            } finally {
                Log(ContaBrenon.Saldo);
            }
            LogStars();

            Log("Teste Erro de numéro de agência negativo.");
            ContaBrenon.Depositar(20);
            Log($"Conta Brenon Saldo: {ContaBrenon.Saldo}");   
            try { 
                var erro = new ContaCorrente(Brenon, 12, -15);
            } catch (ArgumentException e) {
                Log(e.Message);        
            } finally {
                Log(ContaBrenon.Saldo);
            }
            LogStars();


            Log("Teste de sacar mais dinheiro que o disponível na conta.");
            try{
                ContaBrenon.Sacar(8000);
            } catch(SaqueInvalidoException e) {
                Log(e.Message);
            } finally {
                Log(ContaBrenon.Saldo);
            } LogStars();


            Log("Transferência maior que o saldo");
            try {
                ContaLan.Transferir(2500, ContaBrenon);
            } catch (SaqueInvalidoException e) {
                Log(e.Message);
            }
            LogStars();

            Log("Transferência Negativa");
            try { 
                ContaBrenon.Transferir(0, ContaLan); 
            } catch(ArgumentException e) { 
                Console.WriteLine(e.Message); 
            } finally {
                Log(ContaBrenon);
                Log(ContaLan);
            }
            LogStars();

            Log("End");
        }
        static void MetodoErro() => dividir(5,0);
        static double dividir(int dividendo, int divisor) =>  dividendo / divisor;
        static void Log(Object msg) => Console.WriteLine(msg);
        static void Wait() => Console.ReadKey();
        static void LogStars() => Console.WriteLine("********************************************************************************************************");
    }
}