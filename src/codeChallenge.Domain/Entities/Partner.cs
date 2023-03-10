using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace codeChallenge.Domain.Entities
{
    public class Partner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
        public string Document { get; set; }
        public CoverageArea CoverageArea { get; set; }
        public Address Address { get; set; }
    }
}