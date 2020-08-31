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
    public class ObjectController : ControllerBase
    {
        private readonly IObjectService _objectService;

        public ObjectController(IObjectService objectService)
        {
            _objectService = objectService;
        }

        [HttpGet]
        public async Task<IEnumerable<Object>> Get()
        {
            return await _objectService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Object> Get(string id)
        {
            return await _objectService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Object> Post([FromBody] Object obj)
        {
            return await _objectService.AddObjectAsync(obj);
        }

        [HttpPut("{id}")]
        public async Task<Object> Put(string id, [FromBody] Object obj)
        {
            return await _objectService.UpdateObjectAsync(id, obj);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _objectService.RemoveObjectAsync(id);
        }
    }
}
