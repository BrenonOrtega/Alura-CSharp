using System;
using System.ComponentModel.DataAnnotations;
using _01_ByteBank.data.Interfaces;
using _01_ByteBank.data.Exceptions;
using System.Collections.Generic;

namespace _01_ByteBank {

    public class ContaCorrente : ISacavel
    {
        private int _transferenciaInvalidaCounter;
        private int _saqueInvalidoCounter; 
        public static int Instantiations { get; private set; }
        public Cliente Titular { get; set; }
        public int NumeroConta { get; }
        public int NumeroAgencia { get; }
        private double _saldo;
        public double Saldo { 
            get => _saldo; 
            private set => _saldo = IsQuantiaValida(value) ? value 
                                    : throw new SaldoInvalidoException();  
        }
        public ContaCorrente(Cliente titular, int numeroAgencia,  
                            int numeroConta, double saldoInicial = 0
                            ) 
        {
            Titular = titular;
            Saldo = saldoInicial;
            Instantiations ++;

            NumeroAgencia = IsQuantiaValida(numeroAgencia) 
                                ? numeroAgencia 
                                : throw new ArgumentException("Numero de Agência inválido.", nameof(NumeroAgencia) 
                            );

            NumeroConta = IsQuantiaValida(numeroConta) 
                            ? numeroAgencia
                            : throw new ArgumentException("Numero de Conta inválido.", nameof(NumeroConta)
                            );
        }

        private bool IsQuantiaValida(double quantia) => quantia >= 0;
        private bool IsSaqueValido(double quantia) 
        {
            if (Saldo >= quantia && quantia > 0) return true;
            else if (quantia <= 0) throw new ArgumentException("Não é possível sacar valores negativos ou iguais a zero", nameof(quantia));
            else throw new SaqueInvalidoException(Saldo, quantia);
        }
        
        public void Depositar(double quantia) { 
            Saldo += IsQuantiaValida(quantia) ? quantia : throw new ArgumentException("Quantia para depósito Inválida", nameof(quantia)); 
        }

        public void Sacar(double quantia) {
            try { 
                if (IsSaqueValido(quantia)) Saldo -= quantia; 
            } catch(SaqueInvalidoException) {
                _saqueInvalidoCounter++;
                throw;
            }
        }

        public void Transferir(double quantia, ISacavel contaDestino) {
            if (quantia <= 0) {
                throw new ArgumentException("Valor Inválido para transferência", nameof(quantia));
            }
            try {
                Sacar(quantia);
            } catch (SaqueInvalidoException) {
                _transferenciaInvalidaCounter++;
                Console.WriteLine("Quantidade de saques invalidos:"+_transferenciaInvalidaCounter);
                throw;
            }
            
            contaDestino.Depositar(quantia);    
        }

        public override string ToString() {
            string contaCorrRepr = $@"ContaCorrenteObject
                                    Titular: {Titular.Nome}
                                    Numero da Conta:{NumeroConta}
                                    Numero da Agência: {NumeroAgencia}"
                                    ;
            
            return contaCorrRepr.Replace(@"\n", " - ").Replace(" ", "");
        }

    }
}
