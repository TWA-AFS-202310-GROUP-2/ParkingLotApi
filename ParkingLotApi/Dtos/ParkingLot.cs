using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotApi.Dtos
{
    public class ParkingLot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        [Range(10,1000,ErrorMessage = "Capacity must greater than 10 and less than 1000")]
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}
