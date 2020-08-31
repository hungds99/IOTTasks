using IOT.Models.Entity;
using IOT.Repositories.Interface;
using IOT.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOT.Services.Service
{
    /// <summary>
    /// ModelService
    /// </summary>
    /// <author>@HungDinh</author>
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<Model> AddModelAsync(Model model)
        {
            return await _modelRepository.Add(model);
        }

        public async Task<IEnumerable<Model>> GetAll()
        {
            return await _modelRepository.GetAll();
        }

        public async Task<Model> GetByIdAsync(string id)
        {
            return await _modelRepository.GetById(id);
        }

        public async Task<bool> RemoveModelAsync(string id)
        {
            return await _modelRepository.Remove(id);
        }

        public async Task<Model> UpdateModelAsync(string id, Model model)
        {
            return await _modelRepository.Update(id, model);
        }
    }
}
