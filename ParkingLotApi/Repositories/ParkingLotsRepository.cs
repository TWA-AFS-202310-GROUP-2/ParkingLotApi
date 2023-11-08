using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ParkingLotApi.Dtos;
using ParkingLotApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingLotApi.Repositories;

public class ParkingLotsRepository : IParkingLotsRepository
{
    private readonly IMongoCollection<ParkingLot> _dbCollection;
    public ParkingLotsRepository(IOptions<DataBaseSettings> dataBaseSettings)
    {
        var MongoClient = new MongoClient(dataBaseSettings.Value.ConnectionString);
        var MongoDataBase = MongoClient.GetDatabase(dataBaseSettings.Value.DataBaseName);
        _dbCollection = MongoDataBase.GetCollection<ParkingLot>(dataBaseSettings.Value.CollectionName);
    }

    public async Task<ParkingLot> CreateParkingLot(ParkingLot parkingLot)
    {

        await _dbCollection.InsertOneAsync(parkingLot);
        return await GetParkingLotByName(parkingLot.Name);
    }

    public async Task<ParkingLot> GetParkingLotByName(string parkingLotName)
    {
        return await _dbCollection.Find(doc=>doc.Name == parkingLotName).FirstOrDefaultAsync();
    }

    public async Task<List<ParkingLot>> GetAllParkingLots()
    {
        return await _dbCollection.Find(_ => true).ToListAsync();
    }

    public Task DeleteParkingLotByName(string parkingLotName)
    {
        return _dbCollection.DeleteOneAsync(doc => doc.Name == parkingLotName);
    }

    public Task<List<ParkingLot>> GetParkingLotsByPageIndex(int pageIndex, int pageSize=15)
    {
        return _dbCollection.Find(_ => true).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
    }

    public Task<ParkingLot> GetParkingLotsById(string parkingLotId)
    {
        return _dbCollection.Find(doc=>doc.Id ==parkingLotId).FirstOrDefaultAsync();
    }

    public async Task<ParkingLot> PutParkingLot(string id,ParkingLot parkingLot)
    {
        var options = new FindOneAndReplaceOptions<ParkingLot>
        {
            ReturnDocument = ReturnDocument.After
        };
        return await _dbCollection.FindOneAndReplaceAsync<ParkingLot>(doc=>doc.Id == id, parkingLot, options);
    }
}