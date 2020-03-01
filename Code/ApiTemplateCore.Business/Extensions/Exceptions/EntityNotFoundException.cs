using System;
using System.Runtime.Serialization;

namespace ApiTemplate.Core.Business.Extensions.Exceptions
{
    /// <summary>
    /// Excepción personalizada que se debe lanzar cuando una entidad recibida en un endpoint no existe en el sistema
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}