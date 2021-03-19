using System;

namespace _01_ByteBank {

    public class ContaCorrente {

        private int _numeroAgencia; 
        private double _saldo;

        public static int Instantiations { get; private set; }
        public Cliente Titular { get; set; }
        public int NumeroConta { get; set; }
        public int NumeroAgencia { 
            get=> _numeroAgencia; 
            set=> _numeroAgencia = ValorValido(value) 
                ? value : throw new Exception("Valor inválido"); 
        }
        public double Saldo { 
            get => _saldo; 
            private set => _saldo =  ValorValido(value) ? value : 0;
        }

        public ContaCorrente(Cliente titular, int numeroAgencia, int numeroConta, double saldoInicial = 0) {

            this.Titular = titular;
            this.NumeroAgencia = numeroAgencia;
            this.NumeroConta = numeroConta;
            this.Saldo = saldoInicial;
            Instantiations ++;
        }

        public void Depositar(double quantia) {
            if ( ValorValido(quantia) ) {
                Saldo += quantia ;
            }
        }

        public bool Sacar(double quantia){
            if ( OperacaoValida(quantia) ){
                Saldo -= quantia;
                return true;
            }
            return false;
        }

        public bool Transferir(double quantia, ContaCorrente contaDestino){
            bool Saque = this.Sacar(quantia);
            if (Saque) {
                contaDestino.Depositar(quantia);
            }
            return Saque;
        }
        private bool ValorValido(double valor){
            return valor > 0 ; 
        }

        private bool OperacaoValida(double valor) {
            if (Saldo >= valor && ValorValido(valor) ) {
                return true;
            }
            return false;
        }
    }

}
