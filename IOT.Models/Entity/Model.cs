using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Model
    /// </summary>
    /// <author>@HungDinh</author>
    public class Model : Common
    {
        [Required(ErrorMessage ="Model name is required")]
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
