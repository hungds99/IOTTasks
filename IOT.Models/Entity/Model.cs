using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Model
    /// </summary>
    /// <author>@HungDinh</author>
    public class Model : Common
    {
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("thumbnailUrl")]
        public string thumbnailUrl { get; set; }

        [BsonElement("objUrl")]
        public string objUrl { get; set; }

        [BsonElement("placeTypes")]
        public IList<string> placeTypes { get; set; }
    }
}
