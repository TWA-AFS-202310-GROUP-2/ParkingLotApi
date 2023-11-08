using System.ComponentModel.DataAnnotations;

namespace ParkingLotApi
{
    public class ParkingLot
    {
        
        public string Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string Location { get; set; }
    }
}
