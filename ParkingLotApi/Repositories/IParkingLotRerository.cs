using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotRerository
    {
        Task<ParkingLot> CreateParkingLot(ParkingLotDto parkingLotDto);
        Task<ParkingLot?> DeleteParkingLot(string id);
        Task<ActionResult<ParkingLot?>> ReplaceParkingLotAsync(string id, int newCapacity);
        Task<ParkingLot?> GetParkingLotById(string id);
        Task<List<ParkingLot>> GetByPageAsync(int pageIndex, int pageSize);
    }
}
