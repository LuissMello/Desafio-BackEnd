using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class BikeRentedException : Exception
    {
        public BikeRentedException()
        {
        }

        public BikeRentedException(string? message) : base(message)
        {
        }

        public BikeRentedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BikeRentedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}