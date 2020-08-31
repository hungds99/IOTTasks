
using MongoDB.Bson.Serialization.Attributes;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Location
    /// </summary>
    /// <author>@HungDinh</author>
    public class Location
    {
        [BsonElement("lng")]
        public double lng { get; set; }

        [BsonElement("lat")]
        public double lat { get; set; }
    }
}
