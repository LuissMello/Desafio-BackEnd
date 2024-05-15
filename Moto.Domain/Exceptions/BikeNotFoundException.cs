using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class BikeNotFoundException : Exception
    {
        public BikeNotFoundException()
        {
        }

        public BikeNotFoundException(string? message) : base(message)
        {
        }

        public BikeNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BikeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}