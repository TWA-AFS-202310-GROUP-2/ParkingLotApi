using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotRerository : IParkingLotRerository
    {
        private readonly IMongoCollection<ParkingLot> _parkingLotCollection;
        public ParkingLotRerository(IOptions<ParkingLotDatabaseSettings> parkingLotDatabaseSettings)
        {
            var mongoclient = new MongoClient(parkingLotDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoclient.GetDatabase(parkingLotDatabaseSettings.Value.DataBaseName);
            _parkingLotCollection = mongoDatabase.GetCollection<ParkingLot>(parkingLotDatabaseSettings.Value.CollectionName);
        }
        public async Task<ParkingLot> CreateParkingLot(ParkingLotDto parkingLotDto)
        {
            await _parkingLotCollection.InsertOneAsync(parkingLotDto.ToEntity());
            return await _parkingLotCollection.Find(p => p.Name == parkingLotDto.Name).FirstAsync();
        }

        public async Task<ParkingLot?> GetParkingLotById(string id)
        {
            var parkingLotById = await _parkingLotCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (parkingLotById is null) { return null; }
            return parkingLotById;
        }
        public async Task<ParkingLot?> DeleteParkingLot(string id)
        {
            var result = await _parkingLotCollection.DeleteOneAsync(p => p.Id == id);
            return await _parkingLotCollection.Find(p =>p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ActionResult<ParkingLot?>> ReplaceParkingLotAsync(string id, int newCapacity)
        {
            var parkingLotBefore = await _parkingLotCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (parkingLotBefore == null)
            {
                return null;
            }
            parkingLotBefore.Capacity = newCapacity;
            await _parkingLotCollection.ReplaceOneAsync(x => x.Id == id, parkingLotBefore);
            var parkingLotAfter = await _parkingLotCollection.Find(x =>x.Id == id).FirstOrDefaultAsync();
            return parkingLotAfter;
        }

        public async Task <List<ParkingLot>> GetByPageAsync(int pageIndex,int pageSize)
        {
            List<ParkingLot> parkingLots = await _parkingLotCollection.Find(_=>true).Skip(pageSize*(pageIndex-1)).Limit(pageSize).ToListAsync();
            return parkingLots;
        }
    }
}
