using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("api/v1/parkinglots")]
    public class ParkingLotController : ControllerBase
    {

        private readonly ParkingLotService parkingLotService;

        public ParkingLotController(ParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> Add(ParkingLotRequest parkingLotRequest)
        {
            //try
            //{
                return Created("", await parkingLotService.Add(parkingLotRequest));
            //}
            //catch (InvalidCapacityException ex)
            //{
            //    return BadRequest();
            //}
        }

    }
}
