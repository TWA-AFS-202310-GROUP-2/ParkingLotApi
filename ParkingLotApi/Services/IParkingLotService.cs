namespace ParkingLotApi.Services
{
    public interface IParkingLotService
    {
        Task<ParkingLot> AddParkingLot(ParkingLotRequest parkingLotRequest);
        Task DeleteParkingLot(string parkingLotId);
        Task<List<ParkingLot>> GetPage(int pageSize, int pageIndex);
        Task<List<ParkingLot>> GetAll();
        Task<ParkingLot> GetById(string parkingLotId);
        Task UpdateParkingLot(string parkingLotId, ParkingLotUpdate parkingLotUpdate);
        Task<ParkingLot> GetByName(string name);
    }
}