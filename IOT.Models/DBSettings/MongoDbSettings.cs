using IOT.Models.Model;

namespace IOT.Models.DBSettings
{
    /// <summary>
    /// MongoDbSettings
    /// </summary>
    /// <author>@HungDinh</author>
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
