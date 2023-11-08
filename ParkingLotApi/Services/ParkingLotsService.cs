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
        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto.Capacity < 10)    
            {
                throw new InvalidCapacityException("Invalid capacity exception.");
            }
            return await parkingRepository.CreateParkingLot(parkingLotDto.ToEntity());
        }
    }
}
