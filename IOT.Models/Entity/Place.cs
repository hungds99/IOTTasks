using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Place
    /// </summary>
    /// <author>@HungDinh</author>
    public class Place : Common
    {
        [BsonElement("location")]
        public Location location { get; set; }

        [BsonElement("address")]
        public string address { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("geometry")]
        public Geometry geometry { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        [BsonElement("types")]
        public IList<string> types { get; set; }

        [BsonElement("website")]
        public string website { get; set; }

        [BsonElement("phone")]
        public string phone { get; set; }

        [BsonElement("source")]
        public Dictionary<string,Object> source { get; set; }
    }
}
