using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class BikeAlreadyRegisteredException : Exception
    {
        public BikeAlreadyRegisteredException()
        {
        }

        public BikeAlreadyRegisteredException(string? message) : base(message)
        {
        }

        public BikeAlreadyRegisteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BikeAlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}