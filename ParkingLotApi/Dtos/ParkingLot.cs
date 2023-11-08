namespace ParkingLotApi.Dtos
{
    public class ParkingLot
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}
