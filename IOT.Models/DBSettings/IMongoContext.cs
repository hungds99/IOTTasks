using MongoDB.Driver;

namespace IOT.Models.DBSettings
{
    /// <summary>
    /// IMongoContext
    /// </summary>
    /// <author>@HungDinh</author>
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
