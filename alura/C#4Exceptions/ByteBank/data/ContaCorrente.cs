using System;
using _01_ByteBank.data.Interfaces;
using _01_ByteBank.data.Exceptions;

namespace _01_ByteBank {

    public class ContaCorrente : ISacavel 
    {
        public static int Instantiations { get; private set; }
        public Cliente Titular { get; set; }
        public int NumeroConta { get; }
        public int NumeroAgencia { get; }
        private double _saldo;
        public double Saldo { get => _saldo; private set => _saldo = ValorValido(value)? value : throw new SaldoInvalidoException(); }
        public ContaCorrente(Cliente titular, int numeroAgencia, 
                            int numeroConta, double saldoInicial = 0) 
        {
            Titular = titular;
            Saldo = saldoInicial;
            Instantiations ++;

            NumeroAgencia = ValorValido(numeroAgencia) 
                ? numeroAgencia 
                : throw new ArgumentException("Numero de Agência inválido", ( nameof(NumeroAgencia)) );

            NumeroConta = ValorValido(numeroConta) 
                ? numeroAgencia
                : throw new ArgumentException("Numero de Conta inválido", (nameof(NumeroConta)) ); 
        }

        public override string ToString()
        {
            return $"ContaCorrenteObject-> Titular: {Titular.Nome} - Numero da Conta:{NumeroConta} - Numero da Agência: {NumeroAgencia}";
        }

        private bool ValorValido(double valor) => valor > 0;
        private bool OperacaoValida(double valor) {
            if (Saldo >= valor && ValorValido(valor) ) {
                return true;
            }
            else throw new SaqueInvalidoException(Saldo, valor);
        }
        
        public void Depositar(double quantia) 
        { 
            if (ValorValido(quantia)) Saldo += quantia ; 
        }

        public void Sacar(double valor) 
        {
            if ( OperacaoValida(valor) ) this.Saldo -= valor;  
        }

        public void Transferir(double valor, ISacavel contaDestino)
        {
            Sacar(valor);
            contaDestino.Depositar(valor);    
        }
    }
}
