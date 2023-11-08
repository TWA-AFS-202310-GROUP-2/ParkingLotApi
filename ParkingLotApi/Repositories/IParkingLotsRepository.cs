﻿using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public interface IParkingLotsRepository
    {
        public Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string id);
        public Task<List<ParkingLot>> CheckPageIndexParkingLot(int? pageIndex);
    }
}
