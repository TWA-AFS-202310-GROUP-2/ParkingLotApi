using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Models;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotsRepository : IParkingLotsRepository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotsRepository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings) 
        {
            var mongoClient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(parkingLotDatabaseSettings.Value.DatabaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLot);
            return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstAsync();
        }

        public async Task DeleteParkingLot(string id)
        {
            await _parkingLotCollection.DeleteOneAsync(a => a.Id == id);
        }

        public async Task<List<ParkingLot>> CheckPageIndexParkingLot(int? pageIndex)
        {
            int pageSize = 15;
            return await _parkingLotCollection.Find(_ => true).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

    }
}
