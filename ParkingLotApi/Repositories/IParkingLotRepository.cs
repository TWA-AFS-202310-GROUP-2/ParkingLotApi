using System.Collections.Generic;
using System.Threading.Tasks;
using ParkingLotApi.Models;

public interface IParkingLotRepository
{
    Task<ParkingLot> AddAsync(ParkingLot parkingLot);
    Task<ParkingLot> GetByIdAsync(string id);
    Task<ParkingLot> GetByNameAsync(string name);
    Task<List<ParkingLot>> GetAllAsync();
    Task<ParkingLot> UpdateAsync(string id, ParkingLot parkingLot);
    Task DeleteByNameAsync(string name);
    Task DeleteByIdAsync(string id);
}