using System.Collections.Generic;
using ParkingLotApi.Models;
using System.Threading.Tasks;
using ParkingLotApi.Dtos;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ParkingLotApi.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IMongoCollection<ParkingLot> parkingLotCollection;

        public ParkingLotRepository(IOptions<ParkingLotConnectionConfig> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            parkingLotCollection = database.GetCollection<ParkingLot>(ParkingLot.CollectionName);
        }
        public async Task<ParkingLot> AddAsync(ParkingLot parkingLot)
        {
            await parkingLotCollection.InsertOneAsync(parkingLot);
            return parkingLot;
        }

        public async Task<ParkingLot> GetByNameAsync(string name)
        {
            ParkingLot parkingLot = await parkingLotCollection.Find(parkingLot => parkingLot.Name == name).FirstOrDefaultAsync();
            return parkingLot;
        }

        public async Task<ParkingLot> GetByIdAsync(string id)
        {
            ParkingLot parkingLot = await parkingLotCollection.Find(parkingLot => parkingLot.Id == id).FirstOrDefaultAsync();
            return parkingLot;
        }

        public async Task<List<ParkingLot>> GetAllAsync()
        {
            return await parkingLotCollection.Find(parkingLot => true).ToListAsync();
        }

        public async Task<List<ParkingLot>> GetByPageAsync(int pageIndex, int pageSize)
        {
            return await parkingLotCollection.Find(parkingLot => true).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

        public async Task<ParkingLot> UpdateAsync(string id, ParkingLot parkingLot)
        {
            await parkingLotCollection.ReplaceOneAsync(parkingLot => parkingLot.Id == id, parkingLot);
            return parkingLot;
        }

        public async Task DeleteByNameAsync(string name)
        {
            await parkingLotCollection.DeleteOneAsync(parkingLot => parkingLot.Name == name);
        }

        public async Task DeleteByIdAsync(string id)
        {
            await parkingLotCollection.DeleteOneAsync(parkingLot => parkingLot.Id == id);
        }
    }
}