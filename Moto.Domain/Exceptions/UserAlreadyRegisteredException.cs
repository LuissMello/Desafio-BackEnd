using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException()
        {
        }

        public UserAlreadyRegisteredException(string? message) : base(message)
        {
        }

        public UserAlreadyRegisteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserAlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}