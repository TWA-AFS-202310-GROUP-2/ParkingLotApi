using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Controllers;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Repositories;

namespace ParkingLotApi.Services
{
    public class ParkingLotServices
    {
        private IParkingLotRerository _parkingLotRerository;
        public ParkingLotServices(IParkingLotRerository parkingLotRerository) 
        {
            this._parkingLotRerository = parkingLotRerository;
        }
        public async Task<ParkingLot> CreateAsync(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto == null || parkingLotDto.Capacity < 10)
            {
                throw new InvalidCapacityException();
            }
            return await _parkingLotRerository.CreateParkingLot(parkingLotDto);
        }

        public async Task<ParkingLot?> GetByIdAsync (string id)
        {
            return await _parkingLotRerository.GetParkingLotById(id);
        }

        public async Task<ActionResult<ParkingLot?>> DeleteAsync(string id)
        {
           return await _parkingLotRerository.DeleteParkingLot(id);
        }

        public async Task<ActionResult<ParkingLot?>> ReplaceAsync(string id, int newCapacity)
        {
            return await _parkingLotRerository.ReplaceParkingLotAsync(id, newCapacity);
        }

        public async Task<List<ParkingLot>> GetByPageAsync(int pageIndex, int pageSize)
        {
            return await _parkingLotRerository.GetByPageAsync(pageIndex, pageSize);
        }
    }
}
