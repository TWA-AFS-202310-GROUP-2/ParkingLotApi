using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string id);
        public Task<List<ParkingLot>> CheckPageIndexParkingLot(int? pageIndex);
        public Task<ParkingLot> GetOneParkingLot(string parkingLotId);
        public Task UpdateOneParkingLot(string parkingLotId, ParkingLotUpdate parkingLotUpdate);
    }
}
