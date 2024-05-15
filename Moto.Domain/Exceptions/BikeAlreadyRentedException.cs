using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class BikeAlreadyRentedException : Exception
    {
        public BikeAlreadyRentedException()
        {
        }

        public BikeAlreadyRentedException(string? message) : base(message)
        {
        }

        public BikeAlreadyRentedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BikeAlreadyRentedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}