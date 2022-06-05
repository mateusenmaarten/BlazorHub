using System.Runtime.Serialization;

namespace CAH.Backend.Exceptions
{

    [Serializable]
    internal class PlayerException : Exception
    {
        public PlayerException()
        {
        }

        public PlayerException(string? message) : base(message)
        {
        }

        public PlayerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}