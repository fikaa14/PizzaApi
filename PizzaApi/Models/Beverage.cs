using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PizzaApi.Models
{

    [BsonIgnoreExtraElements]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Beverage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("address2")]
        public string Containance { get; set; }
    }
}
