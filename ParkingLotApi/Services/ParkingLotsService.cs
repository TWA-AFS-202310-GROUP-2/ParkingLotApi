using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services;

public class ParkingLotsService
{
    private readonly IParkingLotsRepository _parkingLotsRepository;

    public ParkingLotsService(IParkingLotsRepository parkingLotsRepository)
    {
        _parkingLotsRepository = parkingLotsRepository;
    }
    public async Task<ParkingLot> CreateAsync(ParkingLotDto parkingLotDto)
    {
        if (parkingLotDto.Capacity < 10)
        {
            throw new LowCapacityException();
        }

        var result = await _parkingLotsRepository.GetParkingLotByName(parkingLotDto.Name);
        if (result != null)
        {
            throw new ExistingNameException();
        }
        return await _parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
    }

    public async Task DeleteByNameAsync(string parkingLotName)
    {
        if (await _parkingLotsRepository.GetParkingLotByName(parkingLotName) == null)
        {
            throw new NoParkingLotException();
        }

        await _parkingLotsRepository.DeleteParkingLotByName(parkingLotName);
    }
}