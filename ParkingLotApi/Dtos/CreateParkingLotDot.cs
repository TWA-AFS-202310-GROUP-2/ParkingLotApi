namespace ParkingLotApi.Dtos
{
    public class CreateParkingLotDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}