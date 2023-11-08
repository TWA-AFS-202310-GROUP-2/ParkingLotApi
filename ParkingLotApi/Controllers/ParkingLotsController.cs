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
    }
}
