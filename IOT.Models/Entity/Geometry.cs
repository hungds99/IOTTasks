using System.Collections.Generic;

namespace IOT.Models.Entity
{
    /// <summary>
    /// Geometry
    /// </summary>
    /// <author>@HungDinh</author>
    public class Geometry
    {
        public string type { get; set; }
        public IList<Object> coordinates { get; set; }
    }
}
