using ParkingLotApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotApi.Dtos
{
    public class ParkingLotDto
    {
        [Required]
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        public ParkingLot ToEntity()
        {
            return new ParkingLot()
            {
                Name = Name,
                Capacity = Capacity,
                Location = Location
            };
        }
    }
}
