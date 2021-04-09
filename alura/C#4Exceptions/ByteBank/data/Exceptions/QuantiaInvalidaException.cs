using System;
using System.Runtime.Serialization;

namespace _01_ByteBank.data.Exceptions
{
    [Serializable]
    internal class QuantiaInvalidaException : Exception
    {   
        public const string QUANTIA_INVALIDA_MESSAGE = "Argumento \"quantia\" inválido na invocação do método "; 
        public QuantiaInvalidaException()
        {
        }

        public QuantiaInvalidaException(string methodName, string message=QUANTIA_INVALIDA_MESSAGE) : base(message + methodName)
        {
        }
        public QuantiaInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuantiaInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}