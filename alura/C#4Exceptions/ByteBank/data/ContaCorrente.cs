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
        public double Saldo { get => _saldo; private set => _saldo = ValorValido(value)? value : 0; }
        public ContaCorrente(Cliente titular, int numeroAgencia, 
                            int numeroConta, double saldoInicial = 0) 
        {
            Titular = titular;
            Saldo = saldoInicial;
            Instantiations ++;

            NumeroAgencia = ValorValido(numeroAgencia) 
                ? numeroAgencia 
                : throw new IdentificacaoInvalidaException();

            NumeroConta = ValorValido(numeroConta) 
                ? numeroAgencia
                : throw new IdentificacaoInvalidaException(); 
        }

        private bool ValorValido(double valor) => valor > 0;
        private bool OperacaoValida(double valor) {
            if (Saldo >= valor && ValorValido(valor) ) {
                return true;
            }
            return false;
        }
        public void Depositar(double quantia) { 
            if ( ValorValido(quantia) ) Saldo += quantia ;
            else throw new QuantiaInvalidaException(nameof(Depositar));
        }
        public void Sacar(double quantia) {
            if ( ValorValido(quantia) ) this.Saldo -= quantia;
            else throw new QuantiaInvalidaException(nameof(Depositar));
        }

        public void Transferir(double quantia, ISacavel contaDestino){
            Sacar(quantia);
            contaDestino.Depositar(quantia);    
        }
    }
}
