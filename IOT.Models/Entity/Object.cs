using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Object
    /// </summary>
    /// <author>@HungDinh</author>
    public class Object : Common
    {
        [BsonElement("location")]
        public Location location { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        [BsonElement("places")]
        public IList<string> places { get; set; }

        [BsonElement("startDate")]
        public DateTime startDate { get; set; }

        [BsonElement("endDate")]
        public DateTime endDate { get; set; }

        [BsonElement("source")]
        public Dictionary<string, object> source { get; set; }

        [BsonElement("model")]
        public Model model {get;set;}
    }
}
