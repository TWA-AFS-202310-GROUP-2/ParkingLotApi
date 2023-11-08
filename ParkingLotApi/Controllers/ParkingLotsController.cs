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
            return StatusCode(StatusCodes.Status201Created, res);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteParkingLot([FromBody] string name)
        {
            await _parkingLotService.DeleteAsync(name);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLot([FromQuery] int pageIndex)
        {
            var res = await _parkingLotService.GetAsync(pageIndex - 1);
            return StatusCode(StatusCodes.Status200OK, res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotById(string id)
        {
            var res = await _parkingLotService.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLot>> PutParkingLot(string id, [FromBody] int capacity)
        {
            var res = await _parkingLotService.PutAsync(id, capacity);
            return StatusCode(StatusCodes.Status200OK, res);
        }
    }
}