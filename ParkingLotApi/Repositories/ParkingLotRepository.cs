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
            throw new NotImplementedException();
        }

        public async Task<List<ParkingLot>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ParkingLot> UpdateAsync(string id, ParkingLot parkingLot)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByNameAsync(string name)
        {
            await parkingLotCollection.DeleteOneAsync(parkingLot => parkingLot.Name == name);
        }
    }
}