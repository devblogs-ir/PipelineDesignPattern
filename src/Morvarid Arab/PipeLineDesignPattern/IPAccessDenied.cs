using System.Runtime.Serialization;

namespace PipeLineDesignPattern
{
    [Serializable]
    internal class IPAccessDenied : Exception
    {
        public IPAccessDenied()
        {
        }

        public IPAccessDenied(string? message) : base(message)
        {
        }

        public IPAccessDenied(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IPAccessDenied(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}