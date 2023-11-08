using ParkingLotApi.Dtos;

namespace ParkingLotApi.Services
{
    public class ParkingLotServices
    {
        public async Task<ParkingLot> CreateParkingLotAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto == null || parkingLotDto.Capacity < 10)
            {
                throw new ArgumentException();
            }
            return null;
        }
    }
}
