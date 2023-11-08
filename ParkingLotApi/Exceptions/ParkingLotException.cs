using Microsoft.AspNetCore.Http.HttpResults;

namespace ParkingLotApi.ParkingLotExceptions
{
    public class ParkingLotNotFoundException : Exception
    {
        public ParkingLotNotFoundException(string message = "ParkingLot Not Found") : base(message)
        {

        }
    }

    public class ParkingLotIsFullException : Exception
    {
        public ParkingLotIsFullException(string message = "ParkingLot Is Full") : base(message)
        {
        }
    }

    public class ParkingLotHasExistedException : Exception
    {
        public ParkingLotHasExistedException(string message = "ParkingLot Has Existed") : base(message)
        {
        }
    }

    // public class ParkingLotCapacityIsNotValidException : Exception
    // {
    //     public ParkingLotCapacityIsNotValidException(string message = "ParkingLot Capacity Is Not Valid") : base(message)
    //     {
    //     }
    // }
}