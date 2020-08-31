using IOT.Models.Model;
using MongoDB.Driver;

namespace IOT.Models.DBSettings
{
    /// <summary>
    /// MongoContext
    /// </summary>
    /// <author>@HungDinh</author>
    public class MongoContext : IMongoContext
    {
        public MongoContext(IMongoDbSettings connectionSetting)
        {
            var client = new MongoClient(connectionSetting.ConnectionString);
            Database = client.GetDatabase(connectionSetting.DatabaseName);
        }

        public IMongoDatabase Database { get; }
    }
}
