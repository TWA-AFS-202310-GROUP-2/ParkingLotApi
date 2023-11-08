using System.Net;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ParkingLotsService _parkingLotsService;

        public ParkingLotsController(ParkingLotsService parkingLotsService)
        {
            _parkingLotsService = parkingLotsService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateParkingLot([FromBody] ParkingLotDto parkingLotDto)
        {
            return StatusCode(StatusCodes.Status201Created, await _parkingLotsService.CreateAsync(parkingLotDto));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteParkingLot(string parkingLotName)
        {
            await _parkingLotsService.DeleteByNameAsync(parkingLotName);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet]
        [Route("pageIndex")]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotByPagesize(int pageIndex, int pageSize=15)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _parkingLotsService.GetParkingLotListByPageIndex(pageIndex, pageSize));
        }
    }
}