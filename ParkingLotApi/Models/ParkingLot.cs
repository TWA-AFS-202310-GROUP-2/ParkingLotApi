using MongoDB.Bson.Serialization.Attributes;
namespace ParkingLotApi.Models
{
    public class ParkingLot
    {
        public ParkingLot(string name, int capacity, string location)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Location = location;
        }

        public static string CollectionName = "ParkingLot";
        
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String? Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}