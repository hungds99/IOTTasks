using IOT.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOT.Services.Interface
{
    /// <summary>
    /// IPlaceService
    /// </summary>
    /// <author>@HungDinh</author>
    public interface IPlaceService
    {
        Task<Place> AddPlaceAsync(Place place);
        Task<Place> UpdatePlaceAsync(string id, Place place);
        Task<bool> RemovePlaceAsync(string id);
        Task<Place> GetByIdAsync(string id);
        Task<IEnumerable<Place>> GetAll();
    }
}
