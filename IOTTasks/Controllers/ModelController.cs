using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IOT.Models.Entity;
using IOT.Services.Interface;
using IOT.Utilities.Response;
using IOT.ViewModels.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IOTTasks.Controllers
{
    /// <summary>
    /// ModelController
    /// </summary>
    /// <author>@HungDinh</author>
    [Route("api/models")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;

        public ModelController(IModelService modelService, IMapper mapper)
        {
            _modelService = modelService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Models
        /// </summary>
        /// <returns>List model</returns>
        [HttpGet]
        public async Task<APIResponse<IEnumerable<Model>>> Get()
        {
            var models = await _modelService.GetAll();
            return new APIResponse<IEnumerable<Model>>(Ok().StatusCode, "Success", models);
        }

        /// <summary>
        /// Pagination Models
        /// </summary>
        /// <param name="start">start</param>
        /// <param name="limit">limit</param>
        /// <returns>List model by page</returns>
        [HttpGet("page")]
        public async Task<APIResponse<IEnumerable<Model>>> GetPagination(int start, int limit)
        {
            var models = await _modelService.GetModelPaginationAsync(start, limit);
            if(models != null)
            {
                return new APIResponse<IEnumerable<Model>>(Ok().StatusCode, "Success", models);
            }
            return new APIResponse<IEnumerable<Model>>(NotFound().StatusCode, "Models not found", models);
        }

        /// <summary>
        /// Get model by id
        /// </summary>
        /// <param name="id">modelId</param>
        /// <returns>Model by id</returns>
        [HttpGet("{id}")]
        public async Task<APIResponse<Model>> Get(string id)
        {
            var model = await _modelService.GetByIdAsync(id);
            if(model != null)
            {
                return new APIResponse<Model>(Ok().StatusCode, "Success", model);
            }
            return new APIResponse<Model>(NotFound().StatusCode, "Model not found", model);
        }

        /// <summary>
        /// Add new model
        /// </summary>
        /// <param name="modelDto">modeDto</param>
        /// <returns>Model is added</returns>
        [HttpPost]
        public async Task<APIResponse<Model>> Post([FromBody] ModelDto modelDto)
        {
            // Mapping dto with model
            var model = _mapper.Map<Model>(modelDto);
            
            // Valdate model
            if(!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                var err = new { errors = errors };

                return new APIResponse<Model>(400, err, null);
            }

            var modelAdded = await _modelService.AddModelAsync(model);

            if(modelAdded != null)
            {
                return new APIResponse<Model>(201, "Model is created", modelAdded);
            }
            return new APIResponse<Model>(204, "Model is not created", modelAdded);
        }

        /// <summary>
        /// Add many models
        /// </summary>
        /// <param name="models">modelsDto</param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<APIResponse<IEnumerable<Model>>> PostMany([FromBody] IEnumerable<ModelDto> modelDtos)
        {
            // Validate model
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                var err = new { errors = errors };

                return new APIResponse<IEnumerable<Model>>(400, err, null);
            }

            var models = _mapper.Map<IEnumerable<Model>>(modelDtos);

            var modelsAdded = await _modelService.AddManyModelsAsync(models);
            if(modelsAdded != null)
            {
                return new APIResponse<IEnumerable<Model>>(201, "All Models are created", modelsAdded);
            }
            return new APIResponse<IEnumerable<Model>>(204, "All Models are not created", modelsAdded);
        }

        [HttpPut("{id}")]
        public async Task<APIResponse<Model>> Put(string id, [FromBody] Model model)
        {
            // Validate model
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                var err = new { errors = errors };

                return new APIResponse<Model>(400, err, null);
            }

            // var model = _mapper.Map<Model>(modelDto);

            model._id = id;
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
