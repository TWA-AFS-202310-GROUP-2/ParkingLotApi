using System.Runtime.Serialization;

namespace ParkingLotApi.Services
{
    [Serializable]
    internal class DuplicatedNameException : Exception
    {
        public DuplicatedNameException()
        {
        }

        public DuplicatedNameException(string? message) : base(message)
        {
        }

        public DuplicatedNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DuplicatedNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}