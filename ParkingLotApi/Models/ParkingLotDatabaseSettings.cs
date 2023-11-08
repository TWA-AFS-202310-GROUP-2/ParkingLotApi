using MongoDB.Driver;

namespace ParkingLotApi.Models
{
    public class ParkingLotDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
        //public MongoClientSettings Collectionstring { get; set; }
    }
}
