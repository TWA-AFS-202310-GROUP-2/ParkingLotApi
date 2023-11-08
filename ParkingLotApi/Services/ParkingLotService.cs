using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Repositories;
using System.Xml.Linq;

namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        private readonly IParkingLotsRepository parkingLotsRepository;
        public ParkingLotService(IParkingLotsRepository parkingLotsRepository)
        {
            this.parkingLotsRepository = parkingLotsRepository;
        }
        public async Task<ParkingLot> AddAsync(ParkingLotDto parkingLotDto) 
        { 
            if (parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            var res = await parkingLotsRepository.CreateParkingLot(parkingLotDto.ToEntity());
            if (res != null)
            {
                 return res;
            }
            throw new ExistingNameException();
        }
        public async Task DeleteAsync(string name)
        {
            await parkingLotsRepository.DeleteParkingLot(name);
        }
    }
}
