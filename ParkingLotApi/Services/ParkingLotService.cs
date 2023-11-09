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
            var existed = await parkingLotRepository.GetByName(parkingLotRequest.Name);
            if (existed != null)
            {
                throw new DuplicatedNameException("Name cannot be duplicated");
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

        public async Task<ParkingLot> GetById(string parkingLotId)
        {
            var parkingLot = await parkingLotRepository.GetById(parkingLotId);
            if (parkingLot == null)
            {
                throw new ParkingLotNotFoundException();
            }
            return parkingLot;
        }

        public async Task<ParkingLot> GetByName(string name)
        {
            return await parkingLotRepository.GetByName(name);
        }

        public async Task<List<ParkingLot>> GetPage(int pageSize, int pageIndex)
        {
            return await parkingLotRepository.GetPage(pageSize, pageIndex);
        }

        public async Task UpdateParkingLot(string parkingLotId, ParkingLotUpdate parkingLotUpdate)
        {
            if (parkingLotUpdate.Capacity < 10)
            {
                throw new InvalidCapacityException("Capacity cannot less than 10");
            }
            await parkingLotRepository.UpdateParkingLot(parkingLotId, parkingLotUpdate);
        }
    }
}
