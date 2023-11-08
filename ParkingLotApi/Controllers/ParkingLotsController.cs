using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Dtos;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateParkingLot(ParkingLotDto parkingLotDto)
        {
            if (parkingLotDto == null || parkingLotDto.Capacity <10)
            {
                return BadRequest();
            }
            return null;
        }
    }
}
