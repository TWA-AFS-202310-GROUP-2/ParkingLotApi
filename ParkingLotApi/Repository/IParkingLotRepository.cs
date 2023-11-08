namespace ParkingLotApi.Repository
{
    public interface IParkingLotRepository
    {
        public Task<ParkingLot> AddParkingLot(ParkingLot parkingLot);
        public Task DeleteParkingLot(string parkingLotId);
    }
}
