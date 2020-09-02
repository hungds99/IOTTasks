using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Geometry
    /// </summary>
    /// <author>@HungDinh</author>
    public class Geometry
    {
        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("coordinates")]
        public IList<object> coordinates { get; set; }
    }
}
