using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotsService
    {
        private readonly IParkingLotsRepository parkingRepository;
        public ParkingLotsService(IParkingLotsRepository parkingLotsRepository) 
        {
            this.parkingRepository = parkingLotsRepository; 
        }
        public async Task<ParkingLot> AddAsync(ParkingLot parkingLot)
        {
            if (parkingLot.Capacity < 10)    
            {
                throw new InvalidCapacityException("Invalid capacity exception.");
            }
            return await parkingRepository.CreateParkingLot(parkingLot);
        }

        public async Task DeleteAsync(string id)
        {
            await parkingRepository.DeleteParkingLot(id);
        }

        public async Task<List<ParkingLot>> CheckPageIndexAsync(int? pageIndex)
        {
            return await parkingRepository.CheckPageIndexParkingLot(pageIndex);
        }

        public async Task<ParkingLot> GetOneParkingLotAsync(string parkingLotId)
        {
            return await parkingRepository.GetOneParkingLot(parkingLotId);
        }

        public async Task UpdateOneParkingLotAsync(string parkingLotId, ParkingLotUpdate parkingLotUpdate)
        {
            await parkingRepository.UpdateOneParkingLot(parkingLotId, parkingLotUpdate);
        }
    }
}
