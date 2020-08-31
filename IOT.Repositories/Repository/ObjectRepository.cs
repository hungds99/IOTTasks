using IOT.Models.DBSettings;
using IOT.Models.Entity;
using IOT.Repositories.Interface;

namespace IOT.Repositories.Repository
{
    /// <summary>
    /// ObjectRepository
    /// </summary>
    /// <author>@HungDinh</author>
    public class ObjectRepository : MongoRepository<Object>, IObjectRepository
    {
        public ObjectRepository(IMongoContext context) : base (context){ }
    }
}
