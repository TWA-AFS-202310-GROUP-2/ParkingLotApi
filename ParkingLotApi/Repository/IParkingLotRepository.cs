﻿namespace ParkingLotApi.Repository
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> AddParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string parkingLotId);
        public Task<List<ParkingLot>> GetPage(int pageSize, int pageIndex);
        public Task<List<ParkingLot>> Get();
        public Task<ParkingLot> GetById(string parkingLotId);
        public Task UpdateParkingLot(string parkingLotId, ParkingLotUpdate parkingLotUpdate);
    }
}
