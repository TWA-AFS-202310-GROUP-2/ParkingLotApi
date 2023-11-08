using ParkingLotApi.Dtos;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories;

public interface IParkingLotsRepository
{
    public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
    public Task<ParkingLot> GetParkingLotByName(string parkingLotName);
    public Task<List<ParkingLot>> GetAllParkingLots();
    public Task DeleteParkingLotByName(string parkingLotName);
}