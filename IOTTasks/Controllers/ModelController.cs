using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Models.Entity;
using IOT.Services.Interface;
using IOT.Utilities.Response;
using Microsoft.AspNetCore.Mvc;

namespace IOTTasks.Controllers
{
    /// <summary>
    /// ModelController
    /// </summary>
    /// <author>@HungDinh</author>
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<APIResponse<IEnumerable<Model>>> Get()
        {
            var models = await _modelService.GetAll();
            return new APIResponse<IEnumerable<Model>>(Ok().StatusCode, "", models);
        }

        [HttpGet("page")]
        public async Task<APIResponse<IEnumerable<Model>>> GetPagination(int start, int limit)
        {
            var models = await _modelService.GetModelPaginationAsync(start, limit);
            if(models == null)
            {
                return new APIResponse<IEnumerable<Model>>(Ok().StatusCode, "", models);
            }
            return new APIResponse<IEnumerable<Model>>(NotFound().StatusCode, "Models not found", models);
        }

        [HttpGet("{id}")]
        public async Task<APIResponse<Model>> Get(string id)
        {
            var model = await _modelService.GetByIdAsync(id);
            if(model != null)
            {
                return new APIResponse<Model>(Ok().StatusCode, "", model);
            }
            return new APIResponse<Model>(NotFound().StatusCode, "Model not found", model);
        }

        [HttpPost]
        public async Task<APIResponse<Model>> Post([FromBody] Model model)
        {
            var modelAdded = await _modelService.AddModelAsync(model);
            if(modelAdded != null)
            {
                return new APIResponse<Model>(201, "Model is created", modelAdded);
            }
            return new APIResponse<Model>(204, "Model is not created", modelAdded);
        }

        [HttpPut("{id}")]
        public async Task<APIResponse<Model>> Put(string id, [FromBody] Model model)
        {
            var modelUpdated = await _modelService.UpdateModelAsync(id, model);
            if(modelUpdated != null)
            {
                return new APIResponse<Model>(200, "Model is updated", modelUpdated);
            }
            return new APIResponse<Model>(204, "Model is not updated", modelUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<APIResponse<Model>> Delete(string id)
        {
            var isDeleted = await _modelService.RemoveModelAsync(id);
            if(isDeleted)
            {
                return new APIResponse<Model>(200, "Model is removed", new Model());
            }
            return new APIResponse<Model>(400, "Id not found", new Model());
        }
    }
}
