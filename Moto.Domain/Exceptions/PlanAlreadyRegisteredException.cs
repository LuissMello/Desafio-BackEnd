using System.Runtime.Serialization;

namespace Moto.Domain.Exceptions
{
    [Serializable]
    public class PlanAlreadyRegisteredException : Exception
    {
        public PlanAlreadyRegisteredException()
        {
        }

        public PlanAlreadyRegisteredException(string? message) : base(message)
        {
        }

        public PlanAlreadyRegisteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlanAlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}