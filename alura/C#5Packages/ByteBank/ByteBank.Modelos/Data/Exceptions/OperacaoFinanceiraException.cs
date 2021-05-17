using System;
using System.Runtime.Serialization;

namespace ByteBank.Modelos.Data.Exceptions
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException() : base("Operação financeira inválida.") {  }

        public OperacaoFinanceiraException(string message) : base(message) {  }

        public OperacaoFinanceiraException(string message, Exception innerException) : base(message, innerException) {  }

        protected OperacaoFinanceiraException(SerializationInfo info, StreamingContext context) : base(info, context) {   }
    }
}