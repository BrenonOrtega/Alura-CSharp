using System;

namespace _01_ByteBank {

    public class ContaCorrente {

        public Cliente Titular { get; set; }
        public int NumeroAgencia { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; private set; }

        public ContaCorrente(Cliente titular, int numeroAgencia, int numeroConta, double saldoInicial = 0) {

            this.Titular = titular;
            this.NumeroAgencia = numeroAgencia;
            this.NumeroConta = numeroConta;
            this.Saldo = saldoInicial;
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
