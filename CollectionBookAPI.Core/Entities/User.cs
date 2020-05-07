using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CollectionBookAPI.Core.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("userName")]
        public string UserName { get; set; }

        [BsonElement("password")]
        [JsonIgnore]
        public string Password { get; set; }

        [BsonIgnore]
        public string Token { get; set; }
    }
}
