using System;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;
using ParkingLotApi.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using ParkingLotApi.Services;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("api/parkinglots")]
    public class ParkingLotController
    {
        private readonly ParkinglotService _parkinglotService;
        public ParkingLotController(ParkinglotService parkinglotService)
        {
            _parkinglotService = parkinglotService;
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLot>> CreateParkingLot(CreateParkingLotDto createParkingLotDto)
        {
            return await _parkinglotService.AddParkingLot(createParkingLotDto);
        }

    }
}