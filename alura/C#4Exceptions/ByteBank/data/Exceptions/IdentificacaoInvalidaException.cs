using System;
using System.Runtime.Serialization;

namespace _01_ByteBank.data.Exceptions
{
    public class IdentificacaoInvalidaException : Exception
    {
        public IdentificacaoInvalidaException() {  }

        public IdentificacaoInvalidaException(string message) : base(message) { }

        public IdentificacaoInvalidaException(string message, Exception innerException) : base(message, innerException) {  }
        
        protected IdentificacaoInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context) {  }
    }
}