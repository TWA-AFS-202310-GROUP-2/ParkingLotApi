using ParkingLotApi.Dtos;

namespace ParkingLotApi.Services;

public class ParkingLotsService
{
    public async Task<ParkingLotDto> CreateAsync(ParkingLotDto parkingLotDto)
    {
        if (parkingLotDto.Capacity < 10)
        {
            throw new LowCapacityException();
        }

        return null;
    }
}