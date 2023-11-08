using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("api/v1/parkinglots")]
    public class ParkingLotController : ControllerBase
    {

        private readonly IParkingLotService parkingLotService;

        public ParkingLotController(IParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> Add(ParkingLotRequest parkingLotRequest)
        {
            return Created("", await parkingLotService.AddParkingLot(parkingLotRequest));
        }

    }
}
