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
        public async Task<APIResponse<IEnumerable<Object>>> Get()
        {
            var objs = await _objectService.GetAll();
            return new APIResponse<IEnumerable<Object>>(200, "", objs);
        }

        [HttpGet("page")]
        public async Task<APIResponse<IEnumerable<Object>>> GetPagination(int start, int limit)
        {
            var objs = await _objectService.GetObjectPaginationAsync(start, limit);
            if(objs != null)
            {
                return new APIResponse<IEnumerable<Object>>(Ok().StatusCode, "", objs);
            }
            return new APIResponse<IEnumerable<Object>>(NotFound().StatusCode, "Objects not found", objs);
        }

        [HttpGet("{id}")]
        public async Task<APIResponse<Object>> Get(string id)
        {
            var obj = await _objectService.GetByIdAsync(id);
            if(obj != null)
            {
                return new APIResponse<Object>(200, "", obj);
            }
            return new APIResponse<Object>(404, "Object not found", obj);
        }

        [HttpPost]
        public async Task<APIResponse<Object>> Post([FromBody] Object obj)
        {
            var objectAdded = await _objectService.AddObjectAsync(obj);
            if (objectAdded != null)
            {
                return new APIResponse<Object>(201, "Object is created", objectAdded);
            }
            return new APIResponse<Object>(204, "Object is not created", objectAdded);
        }

        [HttpPost("add")]
        public async Task<APIResponse<IEnumerable<Object>>> PostMany([FromBody] IEnumerable<Object> objects)
        {
            var objectsAdded = await _objectService.AddManyObjectsAsync(objects);
            if (objectsAdded != null)
            {
                return new APIResponse<IEnumerable<Object>>(201, "All Objects are created", objectsAdded);
            }
            return new APIResponse<IEnumerable<Object>>(204, "All Objects are not created", objectsAdded);
        }

        [HttpPut("{id}")]
        public async Task<APIResponse<Object>> Put(string id, [FromBody] Object obj)
        {
            var objectUpdated = await _objectService.UpdateObjectAsync(id, obj);
            if (objectUpdated != null)
            {
                return new APIResponse<Object>(200, "Object is updated", objectUpdated);
            }
            return new APIResponse<Object>(204, "Object is not updated", objectUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<APIResponse<Object>> Delete(string id)
        {
            var isDeleted = await _objectService.RemoveObjectAsync(id);
            if (isDeleted)
            {
                return new APIResponse<Object>(200, "Object is removed", new Object());
            }
            return new APIResponse<Object>(400, "Id not found", new Object());
        }
    }
}
