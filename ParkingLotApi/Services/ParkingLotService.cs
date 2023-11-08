using ParkingLotApi.Repository;

namespace ParkingLotApi.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository parkingLotRepository;

        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        public async Task<ParkingLot> AddParkingLot(ParkingLotRequest parkingLotRequest)
        {
            if (parkingLotRequest.Capacity < 10)
            {
                throw new InvalidCapacityException("Capacity cannot less than 10");
            }
            return await parkingLotRepository.AddParkingLot(parkingLotRequest.ToParkingLot());
        }

        public async Task DeleteParkingLot(string parkingLotId)
        {
            await parkingLotRepository.DeleteParkingLot(parkingLotId);
        }

        public async Task<List<ParkingLot>> GetAll()
        {
            return await parkingLotRepository.Get();
        }

        public async Task<List<ParkingLot>> GetPage(int pageSize, int pageIndex)
        {
            return await parkingLotRepository.GetPage(pageSize, pageIndex);
        }
    }
}
