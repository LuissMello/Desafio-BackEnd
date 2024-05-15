using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class InvalidDocumentTypeException : Exception
    {
        public InvalidDocumentTypeException()
        {
        }

        public InvalidDocumentTypeException(string? message) : base(message)
        {
        }

        public InvalidDocumentTypeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidDocumentTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}