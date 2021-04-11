using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace _01_ByteBank.data.Exceptions
{
    internal class SaqueInvalidoException : OperacaoFinanceiraException
    {   
        public const string SAQUE_INVALIDO_MESSAGE = "Tentativa de saque inválida."; 
        public double Saldo { get; }
        public double ValorSaque { get; }

        public SaqueInvalidoException() : base(SAQUE_INVALIDO_MESSAGE) {  }
        private SaqueInvalidoException(string message) : base(message) {  }
        public SaqueInvalidoException(double saldo, double valorSaque) 
            : this( $"Não é possível sacar {valorSaque} de um conta que possui apenas {saldo}.")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        } 
        public SaqueInvalidoException(string message, Exception innerException) : base(message, innerException) {  }
        protected SaqueInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context) {  }
    }
}