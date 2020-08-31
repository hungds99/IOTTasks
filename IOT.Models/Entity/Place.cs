using System.Collections.Generic;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Place
    /// </summary>
    /// <author>@HungDinh</author>
    public class Place : Common
    {
        public Location location { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public Geometry geometry { get; set; }
        public string description { get; set; }
        public IList<string> types { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public Dictionary<string,Object> source { get; set; }
    }
}
