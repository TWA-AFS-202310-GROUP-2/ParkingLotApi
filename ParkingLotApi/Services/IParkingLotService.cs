namespace ParkingLotApi.Services
{
    public interface IParkingLotService
    {
        Task<ParkingLot> AddParkingLot(ParkingLotRequest parkingLotRequest);
        Task DeleteParkingLot(string parkingLotId);
    }
}