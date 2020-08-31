using IOT.Models.Entity;
using IOT.Repositories.Interface;
using IOT.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOT.Services.Service
{
    /// <summary>
    /// PlaceService
    /// </summary>
    /// <author>@HungDinh</author>
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService (IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<Place> AddPlaceAsync(Place place)
        {
            return await _placeRepository.Add(place);
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _placeRepository.GetAll();
        }

        public async Task<Place> GetByIdAsync(string id)
        {
            return await _placeRepository.GetById(id);
        }

        public async Task<bool> RemovePlaceAsync(string id)
        {
            return await _placeRepository.Remove(id);
        }

        public async Task<Place> UpdatePlaceAsync(string id, Place place)
        {
            return await _placeRepository.Update(id, place);
        }
    }
}
