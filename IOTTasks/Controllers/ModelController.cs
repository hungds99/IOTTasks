using System.Collections.Generic;
using System.Threading.Tasks;
using IOT.Models.Entity;
using IOT.Services.Interface;
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
        public async Task<IEnumerable<Model>> Get()
        {
            return await _modelService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Model> Get(string id)
        {
            return await _modelService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Model> Post([FromBody] Model model)
        {
            return await _modelService.AddModelAsync(model);
        }

        [HttpPut("{id}")]
        public async Task<Model> Put(string id, [FromBody] Model model)
        {
            return await _modelService.UpdateModelAsync(id, model);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _modelService.RemoveModelAsync(id);
        }
    }
}
