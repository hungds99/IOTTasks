using IOT.Models.DBSettings;
using IOT.Models.Entity;
using IOT.Repositories.Interface;

namespace IOT.Repositories.Repository
{
    /// <summary>
    /// ModelRepository
    /// </summary>
    /// <author>@HungDinh</author>
    public class ModelRepository : MongoRepository<Model>, IModelRepository
    {
        public ModelRepository(IMongoContext context) : base (context){ }
    }
}
