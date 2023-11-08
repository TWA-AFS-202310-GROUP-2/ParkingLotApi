namespace ParkingLotApi.Services
{
    public class ParkingLotService
    {
        public async Task<ParkingLot> Add(ParkingLotRequest parkingLotRequest)
        {
            if (parkingLotRequest.Capacity < 10)
            {
                throw new InvalidCapacityException("");
            }
            return new ParkingLot();
        }
    }
}
