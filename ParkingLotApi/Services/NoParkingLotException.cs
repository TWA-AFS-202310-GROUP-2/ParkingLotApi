using System.Runtime.Serialization;

namespace ParkingLotApi.Services
{
    [Serializable]
    internal class NoParkingLotException : Exception
    {
        public NoParkingLotException()
        {
        }

        public NoParkingLotException(string? message) : base(message)
        {
        }

        public NoParkingLotException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoParkingLotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}