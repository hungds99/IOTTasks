using IOT.Models.Entity;
using IOT.Repositories.Interface;
using IOT.Services.Interface;
using System;
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

        public async Task<IEnumerable<Place>> AddManyPlacesAsync(IEnumerable<Place> places)
        {
            IEnumerable<Place> placesAdded;
            try
            {
                placesAdded = await _placeRepository.AddMany(places);
            } catch (Exception e)
            {
                throw e;
            }
            return placesAdded;
        }

        public async Task<Place> AddPlaceAsync(Place place)
        {
            Place placeAdded;
            try
            {
                placeAdded = await _placeRepository.Add(place);
            }
            catch (Exception e)
            {
                throw e;
            }
            return placeAdded;
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _placeRepository.GetAll();
        }

        public async Task<Place> GetByIdAsync(string id)
        {
            Place place;
            try
            {
                place = await _placeRepository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return place;
        }

        public async Task<IEnumerable<Place>> GetPlacePaginationAsync(int start, int limit)
        {
            IEnumerable<Place> places;
            try
            {
                places = await _placeRepository.GetPagination(start, limit);
            } catch (Exception e)
            {
                throw e;
            }
            return places;
        }

        public async Task<bool> RemovePlaceAsync(string id)
        {
            bool isPlaceRemoved;
            try
            {
                isPlaceRemoved = await _placeRepository.Remove(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return isPlaceRemoved;
        }

        public async Task<Place> UpdatePlaceAsync(string id, Place place)
        {
            var placeExisted = await GetByIdAsync(id);
            Place plc;
            if (placeExisted != null)
            {
                try
                {
                    plc = await _placeRepository.Update(id, place);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return placeExisted;
            }
            return plc;
        }
    }
}
