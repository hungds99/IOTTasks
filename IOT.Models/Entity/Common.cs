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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public bool isDeleted { get; set; }
    }
}
