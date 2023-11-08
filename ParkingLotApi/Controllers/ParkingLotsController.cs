using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;
using System.Net;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotService _parkingLotService;
        public ParkingLotsController(ParkingLotService parkingLotService)
        {
            this._parkingLotService = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLot([FromBody] ParkingLotDto parkingLotDto)
        {
            var res = await _parkingLotService.AddAsync(parkingLotDto);
            if (res == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return StatusCode(StatusCodes.Status201Created, await _parkingLotService.AddAsync(parkingLotDto));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteParkingLot([FromBody] string name)
        {
            await _parkingLotService.DeleteAsync(name);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("{pageIndex}")]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLot(int pageIndex)
        {
            var res = await _parkingLotService.GetAsync(pageIndex - 1);
            return StatusCode(StatusCodes.Status200OK, res);
        }
    }
}