using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Services;
using System.Data;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private ParkingLotServices _parkingLotservices;
        public ParkingLotsController(ParkingLotServices parkingLotServices)
        {
            this._parkingLotservices = parkingLotServices;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateParkingLotAsync(ParkingLotDto parkingLotDto)
        {
            return await _parkingLotservices.CreateAsync(parkingLotDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot?>> GetParkingLotByIdAsync(string id)
        {
            return await _parkingLotservices.GetByIdAsync(id);
        }

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<ActionResult<List<ParkingLot>>> GetByPageAsync(int pageIndex, int pageSize)
        {
            //List<ParkingLot> parkingLots = new List<ParkingLot>();
            for (int i = 1; i < 100; i++)
            {
                ParkingLotDto parkingLotDto = new ParkingLotDto { Name = $"Parking Lot {i}", Capacity = 50, Location = $"Location {i}" };
                await _parkingLotservices.CreateAsync(parkingLotDto);
            }
            return StatusCode(StatusCodes.Status200OK, await _parkingLotservices.GetByPageAsync(pageIndex, pageSize));
        }

        [HttpPut]
        public async Task<ActionResult<ParkingLot?>> ReplaceParkingLotAsync(string id, int newCapacity)
        {
            return await _parkingLotservices.ReplaceAsync(id, newCapacity);
        }

        [HttpDelete]
        public async Task<ActionResult<ParkingLot?>> DeleteParkingLot(string id)
        {
            return await _parkingLotservices.DeleteAsync(id);
        }
    }
}
