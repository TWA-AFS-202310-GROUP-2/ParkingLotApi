using System.ComponentModel.DataAnnotations;
namespace ParkingLotApi.Dtos
{
    public class CreateParkingLotDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(10, 1000, ErrorMessage = "Capacity should be between 10 and 1000")]
        public int Capacity { get; set; }
        [Required]
        public string Location { get; set; }
    }
}