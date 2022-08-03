using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IMongoCollection<Pizza> _pizzaCollection;
        private readonly IMetadataService _metadataService;
        public PizzaService(
            IOptions<PizzaApiDatabaseSettings> pizzaApiDatabaseSettings, IMetadataService metadataService)
        {
            var mongoClient = new MongoClient(
                                pizzaApiDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                                    pizzaApiDatabaseSettings.Value.DatabaseName);

            _pizzaCollection = mongoDatabase.GetCollection<Pizza>(
                                    pizzaApiDatabaseSettings.Value.PizzaCollectionName);
            _metadataService = metadataService;
        }

        public async Task CreateAsync(Pizza pizza)
        { 
            await _pizzaCollection.InsertOneAsync(pizza);
            _metadataService.SaveMetadata(pizza);
            
        }

        public async Task<List<Pizza>> GetAsync() =>
            await _pizzaCollection.Find(_ => true).ToListAsync();

        public async Task<Pizza> GetByIdAsync(string id) =>
            await _pizzaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();


        public async Task RemoveAsync(string id) => 
            await _pizzaCollection.DeleteOneAsync(x => id == x.Id);

    }
}
