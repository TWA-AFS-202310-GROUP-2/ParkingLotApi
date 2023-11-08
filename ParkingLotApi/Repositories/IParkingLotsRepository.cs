using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string name);
        public Task<List<ParkingLot>> GetParkingLot(int pageIndex);
        public Task<ParkingLot> GetParkingLotById(string id);
        public Task<ParkingLot> PutParkingLot(string id, int capacity);

    }
}
