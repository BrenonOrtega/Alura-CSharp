using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace _01_ByteBank.data.Exceptions
{
    [Serializable]
    internal class SaqueInvalidoException : Exception
    {   
        public const string QUANTIA_INVALIDA_MESSAGE = "Tentativa de saque inválido."; 
        public double Saldo { get; set; }
        public double ValorSaque { get; set; }
        public SaqueInvalidoException()
        {
        }

        public SaqueInvalidoException(string message=QUANTIA_INVALIDA_MESSAGE) : base(message)
        {
        }

        public SaqueInvalidoException(double saldo, double valorSaque, string message = QUANTIA_INVALIDA_MESSAGE) 
            : this(message += (valorSaque > saldo) ? $" Não é possível sacar {valorSaque} de uma Conta com apenas {saldo.ToString()}"
                                                : valorSaque <=0 ? "Não é possível sacar um valor negativo ou igual a zero.": "")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
        public SaqueInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaqueInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}