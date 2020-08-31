using System.Collections.Generic;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Model
    /// </summary>
    /// <author>@HungDinh</author>
    public class Model : Common
    {
        public string name { get; set; }
        public string thumbnailUrl { get; set; }
        public string objUrl { get; set; }
        public IList<string> placeTypes { get; set; }
    }
}
