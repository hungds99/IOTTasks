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
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime createdAt { get; set; }

        [BsonElement("updatedAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime updatedAt { get; set; }

        [BsonElement("createdBy")]
        public string createdBy { get; set; }

        [BsonElement("updatedBy")]
        public string updatedBy { get; set; }

        [BsonElement("isDeleted")]
        public bool isDeleted { get; set; }

        public void setCreatedAt(DateTime createdAt)
        {
            this.createdAt = createdAt;
        }

        public void setUpdatedAt(DateTime updatedAt)
        {
            this.updatedAt = updatedAt;
        }
    }
}
