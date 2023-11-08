namespace ParkingLotApi.Models
{
    public class ParkingLot
    {
        public ParkingLot(string name, int capacity, string location)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Capacity = capacity;
            this.Location = location;
        }
        public String Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}