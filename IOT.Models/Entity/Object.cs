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
        public Location location { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public IList<string> places { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Dictionary<string, object> source { get; set; }
        public Model model {get;set;}
    }
}
