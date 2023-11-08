using System;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;
using ParkingLotApi.Dtos;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("api/parkinglots")]
    public class ParkingLotController
    {
        private readonly ILogger<ParkingLotController> _logger;

        public ParkingLotController(ILogger<ParkingLotController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateParkingLot(CreateParkingLotDto createParkingLotDto)
        {
            throw new NotImplementedException();
        }

    }
}