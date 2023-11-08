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

    public async Task<List<ParkingLot>> GetParkingLotListByPageIndex(int pageIndex, int pageSize=15)
    {
        return await _parkingLotsRepository.GetParkingLotsByPageIndex(pageIndex, pageSize);
    }

    public async Task<ParkingLot> GetParkingLotById(string id)
    {
        var parkingLot = await _parkingLotsRepository.GetParkingLotsById(id);
        if (parkingLot == null)
        {
            throw new NoParkingLotException();
        }
        return parkingLot;
    }

    public async Task<ParkingLot?> UpdateParkingLotById(string id, int newCapacity)
    {
        if ( newCapacity< 10)
        {
            throw new LowCapacityException();
        }

        var oldParkingLot = await GetParkingLotById(id);
        oldParkingLot.Capacity = newCapacity;
        return await _parkingLotsRepository.PutParkingLot(id, oldParkingLot);
    }
}