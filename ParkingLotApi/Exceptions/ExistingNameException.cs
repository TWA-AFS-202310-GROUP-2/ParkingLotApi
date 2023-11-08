using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class ExistingNameException : Exception
    {
        public ExistingNameException()
        {
        }

        public ExistingNameException(string? message) : base(message)
        {
        }

        public ExistingNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ExistingNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}