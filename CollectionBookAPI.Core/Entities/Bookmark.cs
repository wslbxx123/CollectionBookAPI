using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CollectionBookAPI.Core
{
    public class Bookmark
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("link")]
        public string Link { get; set; }

        [BsonElement("owner")]
        public string Owner { get; set; }

        [BsonElement("tag")]
        public string Tag { get; set; }
    }
}
