using System;
using System.Runtime.Serialization;

namespace _01_ByteBank.data.Exceptions
{
    public class SaldoInvalidoException : OperacaoFinanceiraException
    {
        private const String SALDO_INVALIDO_MESSAGE = "Valor de atribuição de Saldo Inválido.";
        public SaldoInvalidoException() : this(SALDO_INVALIDO_MESSAGE) {  }
        public SaldoInvalidoException(string message = SALDO_INVALIDO_MESSAGE ) : base(message) {  }
        public SaldoInvalidoException(string message, Exception innerException) : base(message, innerException) {  }
        protected SaldoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context) {  }
    }
}