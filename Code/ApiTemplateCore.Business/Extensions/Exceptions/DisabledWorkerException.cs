using System;
using System.Runtime.Serialization;

namespace ApiTemplate.Core.Business.Extensions.Exceptions
{
    /// <summary>
    /// Excepción personalizada que se debe lanzar cuando se intenta hacer una operación sobre un trabajador deshabilitado
    /// </summary>
    [Serializable]
    public class DisabledWorkerException : Exception
    {
        public DisabledWorkerException()
        {
        }

        public DisabledWorkerException(string message) : base(message)
        {
        }

        public DisabledWorkerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DisabledWorkerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}