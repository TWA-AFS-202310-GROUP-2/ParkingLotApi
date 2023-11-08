using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class NotParkingLotofIdException : Exception
    {
        public NotParkingLotofIdException()
        {
        }

        public NotParkingLotofIdException(string? message) : base(message)
        {
        }
    }
}