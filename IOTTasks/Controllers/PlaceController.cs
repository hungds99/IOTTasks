using System.Collections.Generic;
using System.Threading.Tasks;
using IOT.Models.Entity;
using IOT.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IOTTasks.Controllers
{
    /// <summary>
    /// ObjectController
    /// </summary>
    /// <author>@HungDinh</author>
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Place>> Get()
        {
            return await _placeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Place> Get(string id)
        {
            return await _placeService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Place> Post([FromBody] Place place)
        {
            return await _placeService.AddPlaceAsync(place);
        }

        [HttpPut("{id}")]
        public async Task<Place> Put(string id, [FromBody] Place place)
        {
            return await _placeService.UpdatePlaceAsync(id, place);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _placeService.RemovePlaceAsync(id);
        }
    }
}
