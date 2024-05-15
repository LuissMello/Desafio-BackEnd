using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class RentNotFoundException : Exception
    {
        public RentNotFoundException()
        {
        }

        public RentNotFoundException(string? message) : base(message)
        {
        }

        public RentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}