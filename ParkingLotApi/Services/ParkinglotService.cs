using System.Collections.Generic;
using System.Linq;
using ParkingLotApi.Models;
using ParkingLotApi.Dtos;
using ParkingLotApi.Repositories;
using ParkingLotApi.ParkingLotExceptions;
namespace ParkingLotApi.Services
{ 
    public class ParkinglotService
    {
        private IParkingLotRepository ParkingLotRepository { get; }
        public ParkinglotService(IParkingLotRepository parkingLotRepository)
        {
            this.ParkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLot> AddParkingLot(CreateParkingLotDto createParkingLotDto)
        {
            // Todo: using mapping is better?
            ParkingLot parkingLot = new ParkingLot(createParkingLotDto.Name, createParkingLotDto.Capacity, createParkingLotDto.Location);
            // if (createParkingLotDto.Capacity < 10 || createParkingLotDto.Capacity > 1000)
            // {
            //     throw new ParkingLotCapacityIsNotValidException();
            // } else
            if (await this.ParkingLotRepository.GetByNameAsync(parkingLot.Name) != null)
            {
                throw new ParkingLotHasExistedException();
            }   
            return await this.ParkingLotRepository.AddAsync(parkingLot);
        }

        public async Task DeleteParkingLot(string id)
        {
            if (await this.ParkingLotRepository.GetByIdAsync(id) == null)
            {
                throw new ParkingLotNotFoundException();
            }
            await this.ParkingLotRepository.DeleteByIdAsync(id);
        }
    }
}