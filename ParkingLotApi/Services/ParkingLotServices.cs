using Microsoft.AspNetCore.Http.HttpResults;
using ParkingLotApi.Controllers;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Services
{
    public class ParkingLotServices
    {
        public async Task<ParkingLot> CreateParkingLotAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto == null || parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return null;
        }
    }
}
