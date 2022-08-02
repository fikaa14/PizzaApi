using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PizzaApi.Models
{
    [BsonIgnoreExtraElements]
    public class Pizza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("address1")]
        public string Address1  { get; set; }

        [BsonElement("address2")]
        public string Address2  { get; set; }

    }
}
