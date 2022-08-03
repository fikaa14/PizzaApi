﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PizzaApi.Models
{
    [BsonIgnoreExtraElements]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Pizza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("address1")]
        public string Address1  { get; set; }

        [BsonElement("address2")]
        public string Address2  { get; set; }

    }
}
