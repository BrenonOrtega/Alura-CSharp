using System;
using System.Runtime.Serialization;

namespace _01_ByteBank.data.Exceptions
{
    public class SaldoInvalidoException : Exception
    {
        private const String ErrorMessage = "Valor de Saldo Inválido.";
        public SaldoInvalidoException(string message = ErrorMessage ) : base(message)
        {
        }

        public SaldoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaldoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}