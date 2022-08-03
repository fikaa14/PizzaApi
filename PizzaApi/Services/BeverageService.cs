using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Services
{
    public class BeverageService : IBeverageService
    {
        private readonly IMongoCollection<Beverage> _beverageCollection;
        private readonly IBackupService _backupService;

        public BeverageService(IOptions<PizzaApiDatabaseSettings> pizzaApiDatabaseSettings)
        {
            var mongoClient = new MongoClient(pizzaApiDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(pizzaApiDatabaseSettings.Value.DatabaseName);
            
            _beverageCollection = mongoDatabase.GetCollection<Beverage>(
                                    pizzaApiDatabaseSettings.Value.BeverageCollectionName);
        }

        public async Task CreateBeverage(Beverage beverage)
        {
            await _beverageCollection.InsertOneAsync(beverage);        
        }
   
        public async Task<List<Beverage>> GetAsync() =>
            await _beverageCollection.Find(_ => true).ToListAsync();
    }
}
