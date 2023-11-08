using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private ParkingLotsService _parkingLotsService;
        private static List<ParkingLotDto> parkingLotDtos = new List<ParkingLotDto>();
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            this._parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> AddParkingLotAsync([FromBody] ParkingLot parkingLot)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLot));
        }

        [HttpDelete("{parkingLotId}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string parkingLotId)
        {
            if (parkingLotId != null)
            {
                await _parkingLotsService.DeleteAsync(parkingLotId);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpGet]
        public async Task<List<ParkingLot>> GetParkingLotsFromPageIndexAsync([FromQuery] int? pageIndex)
        {
            return await _parkingLotsService.CheckPageIndexAsync(pageIndex);
        }

        [HttpGet("{parkingLotId}")]
        public async Task<ParkingLot> GetOneParkingLotAsync(string parkingLotId)
        {
            return await _parkingLotsService.GetOneParkingLotAsync(parkingLotId);
        }

        [HttpPut("{parkingLotId}")]
        public async Task<ActionResult<ParkingLot>> UpdateOneParkingLotCapacityAsync(string parkingLotId, ParkingLotUpdate parkingLotUpdate)
        {
            var parkingLotFind = await _parkingLotsService.GetOneParkingLotAsync(parkingLotId);
            await _parkingLotsService.UpdateOneParkingLotAsync(parkingLotId, parkingLotUpdate);
            return Ok(await _parkingLotsService.GetOneParkingLotAsync(parkingLotFind.Id));
        }
    }
}