using System.ComponentModel.DataAnnotations;
namespace ParkingLotApi.Dtos
{
    public class UpdateParkingLotDto
    {
        // public string Name { get; set; }
        [Range(10, 1000, ErrorMessage = "Capacity should be between 10 and 1000")]
        public int? Capacity { get; set; }
        public string? Location { get; set; }
    }
}