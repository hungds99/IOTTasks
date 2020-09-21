using System.Collections.Generic;
using System.Threading.Tasks;
using IOT.Models.Entity;
using IOT.Services.Interface;
using IOT.Utilities.Response;
using Microsoft.AspNetCore.Mvc;

namespace IOTTasks.Controllers
{
    /// <summary>
    /// ObjectController
    /// </summary>
    /// <author>@HungDinh</author>
    [Route("api/places")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<APIResponse<IEnumerable<Place>>> Get()
        {
            var places = await _placeService.GetAll();
            return new APIResponse<IEnumerable<Place>>(Ok().StatusCode, "", places);
        }

        [HttpGet("page")]
        public async Task<APIResponse<IEnumerable<Place>>> GetPagination(int start, int limit)
        {
            var places = await _placeService.GetPlacePaginationAsync(start, limit);
            if(places != null)
            {
                return new APIResponse<IEnumerable<Place>>(Ok().StatusCode, "", places);
            }
            return new APIResponse<IEnumerable<Place>>(NotFound().StatusCode, "Places not found", places);
        }

        [HttpGet("{id}")]
        public async Task<APIResponse<Place>> Get(string id)
        {
            var place = await _placeService.GetByIdAsync(id);
            if (place != null)
            {
                return new APIResponse<Place>(Ok().StatusCode, "", place);
            }
            return new APIResponse<Place>(NotFound().StatusCode, "Place not found", place);
        }

        [HttpPost]
        public async Task<APIResponse<Place>> Post([FromBody] Place place)
        {
            var placeAdded = await _placeService.AddPlaceAsync(place);
            if (placeAdded != null)
            {
                return new APIResponse<Place>(201, "Place is created", placeAdded);
            }
            return new APIResponse<Place>(204, "Place is not created", placeAdded);
        }

        [HttpPost("add")]
        public async Task<APIResponse<IEnumerable<Place>>> PostMany([FromBody] IEnumerable<Place> places)
        {
            var placessAdded = await _placeService.AddManyPlacesAsync(places);
            if (placessAdded != null)
            {
                return new APIResponse<IEnumerable<Place>>(201, "All Places are created", placessAdded);
            }
            return new APIResponse<IEnumerable<Place>>(204, "All Places are not created", placessAdded);
        }

        [HttpPut("{id}")]
        public async Task<APIResponse<Place>> Put(string id, [FromBody] Place place)
        {
            place._id = id;
            var placeUpdated = await _placeService.UpdatePlaceAsync(id, place);
            if (placeUpdated != null)
            {
                return new APIResponse<Place>(200, "Place is updated", placeUpdated);
            }
            return new APIResponse<Place>(204, "Place is not updated", placeUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<APIResponse<Place>> Delete(string id)
        {
            var isDeleted = await _placeService.RemovePlaceAsync(id);
            if (isDeleted)
            {
                return new APIResponse<Place>(200, "Place is removed", new Place());
            }
            return new APIResponse<Place>(400, "Id not found", new Place());
        }
    }
}
