using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Common
    /// </summary>
    /// <author>@HungDinh</author>
    public class Common
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime createdAt { get; set; } = DateTime.Now;

        [BsonElement("updatedAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime updatedAt { get; set; } = DateTime.Now;

        [BsonElement("createdBy")]
        public string createdBy { get; set; }

        [BsonElement("updatedBy")]
        public string updatedBy { get; set; }

        [BsonElement("isDeleted")]
        public bool isDeleted { get; set; }
    }
}
