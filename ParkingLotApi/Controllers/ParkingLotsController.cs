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
            try
            {
                await _parkingLotsService.DeleteByNameAsync(parkingLotName);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (NoParkingLotException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ParkingLot>>> GetParkingLotByPagesize([FromQuery]int pageIndex, [FromQuery]int pageSize=15)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _parkingLotsService.GetParkingLotListByPageIndex(pageIndex, pageSize));
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<ParkingLot>> GetParkingLotById(string id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.GetParkingLotById(id));
            }
            catch (NoParkingLotException e)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (FormatException e)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpPut]
        [Route("id")]
        public async Task<ActionResult<ParkingLot>> UpdateParkingLotById(string id, int newCapacity)
        {
            return StatusCode(StatusCodes.Status200OK, await _parkingLotsService.UpdateParkingLotById(id, newCapacity));
        }

    }
}