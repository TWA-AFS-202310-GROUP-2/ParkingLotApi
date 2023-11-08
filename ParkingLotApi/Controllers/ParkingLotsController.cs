using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Exceptions;
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
        public async Task<ActionResult<ParkingLotDto>> AddParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.AddAsync(parkingLotDto));
        }

        [HttpDelete("{parkingLotName}")]
        public async Task<ActionResult> DeleteParkingLotAsync(string parkingLotName)
        {
            if (parkingLotName != null)
            {
                await _parkingLotsService.DeleteAsync(parkingLotName);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}