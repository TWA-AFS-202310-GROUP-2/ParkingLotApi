using System.Net;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingLotsService _parkingLotsService;
        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            _parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAsync([FromBody] ParkingLotDto parkingLotDto)
        {
            try
            {
                return  StatusCode(StatusCodes.Status201Created,await _parkingLotsService.CreateAsync(parkingLotDto));

            }
            catch (LowCapacityException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}