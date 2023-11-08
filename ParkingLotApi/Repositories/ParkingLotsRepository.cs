using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Models;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var res = await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstOrDefaultAsync();
            if(res == null)
            {
                await _parkingLotCollection.InsertOneAsync(parkingLot);
                return await _parkingLotCollection.Find(a => a.Name == parkingLot.Name).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task DeleteParkingLot(string name)
        {
            await _parkingLotCollection.DeleteOneAsync(e => e.Name == name);
        }

        public async Task<List<ParkingLot>> GetParkingLot(int pageIndex)
        {
            return await _parkingLotCollection.Find(_ => true).Skip(pageIndex * 15).Limit(15).ToListAsync();
        }

        public async Task<ParkingLot> GetParkingLotById(string id)
        {
            return await _parkingLotCollection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ParkingLot> PutParkingLot(string id, int capacity)
        {
            var findParkingLot = await _parkingLotCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
            if(findParkingLot == null)
            {
                return null;
            }

            findParkingLot.Capacity = capacity;

            var options = new FindOneAndReplaceOptions<ParkingLot>
            {
                ReturnDocument = ReturnDocument.After
            };
            var up = await _parkingLotCollection.FindOneAndReplaceAsync<ParkingLot>(u => u.Id == findParkingLot.Id, findParkingLot, options);
            return up;
        }
    }
}
