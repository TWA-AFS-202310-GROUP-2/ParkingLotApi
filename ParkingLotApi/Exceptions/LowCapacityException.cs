using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class LowCapacityException : Exception
    {
        public LowCapacityException()
        {
        }

        public LowCapacityException(string? message) : base(message)
        {
        }

        public LowCapacityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LowCapacityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}