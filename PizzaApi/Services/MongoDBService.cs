using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Services
{
    public class MongoDBService //: IPizzaService
    {
        private readonly IMongoCollection<Pizza> _pizzaCollection;

        public MongoDBService(IOptions<PizzaApiDatabaseSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _pizzaCollection = database.GetCollection<Pizza>(mongoDBSettings.Value.PizzaCollectionName);
        }

        public async Task<List<Pizza>> GetAsync() => 
             await _pizzaCollection.Find(_ => true).ToListAsync();
    }
}
