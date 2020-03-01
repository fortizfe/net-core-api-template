using System;
using System.Runtime.Serialization;

namespace ApiTemplate.Core.Business.Extensions.Exceptions
{
    /// <summary>
    ///  Excepción personalizada que se debe lanzar cuando un parámetro recibido en un endpoint no está en el formato correcto
    /// </summary>
    [Serializable]
    public class InvalidParameterFormatException : Exception
    {
        public InvalidParameterFormatException()
        {
        }

        public InvalidParameterFormatException(string message) : base(message)
        {
        }

        public InvalidParameterFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidParameterFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}