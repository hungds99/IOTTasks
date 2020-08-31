
namespace IOT.Models.Model
{
    /// <summary>
    /// IMongoDbSettings
    /// </summary>
    /// <author>@HungDinh</author>
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
