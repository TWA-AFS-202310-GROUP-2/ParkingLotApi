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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await parkingLotService.DeleteParkingLot(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> Get(int? pageSize, int? pageIndex)
        {
            if (pageSize != null && pageIndex != null)
            {
                return Ok(await parkingLotService.GetPage((int)pageSize, (int)pageIndex));
            }
            else
            {
                return Ok(await parkingLotService.GetAll());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetById(string id)
        {
            var parkingLot = await parkingLotService.GetById(id);
            return Ok(parkingLot);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLot>> UpdateById(string id,ParkingLotUpdate parkingLotUpdate)
        {
            var parkingLotFind = await parkingLotService.GetById(id);
            await parkingLotService.UpdateParkingLot(id,parkingLotUpdate);
            return Ok(await parkingLotService.GetById(parkingLotFind.Id));
        }

    }
}
