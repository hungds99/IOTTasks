using IOT.Models.DBSettings;
using IOT.Models.Entity;
using IOT.Repositories.Interface;

namespace IOT.Repositories.Repository
{
    /// <summary>
    /// PlaceRepository
    /// </summary>
    /// <author>@HungDinh</author>
    public class PlaceRepository : MongoRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(IMongoContext context) : base(context) { }
    }
}
