using IOT.Models.Entity;
using IOT.Repositories.Interface;
using IOT.Services.Interface;
using System;
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

        public async Task<IEnumerable<Model>> AddManyModelsAsync(IEnumerable<Model> models)
        {
            IEnumerable<Model> modelsAdded;
            try
            {
                modelsAdded = await _modelRepository.AddMany(models);
            }catch(Exception e)
            {
                throw e;
            }
            return modelsAdded;
        }

        public async Task<Model> AddModelAsync(Model model)
        {
            Model modelAdded;
            try
            {
                model.setCreatedAt(DateTime.UtcNow);
                modelAdded = await _modelRepository.Add(model);
            }
            catch (Exception e)
            {
                throw e;
            }
            return modelAdded;
        }

        public async Task<IEnumerable<Model>> GetAll()
        {
            return await _modelRepository.GetAll();
        }

        public async Task<Model> GetByIdAsync(string id)
        {
            Model model;
            try
            {
                model = await _modelRepository.GetById(id);
            } catch (Exception e)
            {
                throw e;
            }
            return model;
        }

        public async Task<IEnumerable<Model>> GetModelPaginationAsync(int start, int limit)
        {
            IEnumerable<Model> models;
            try
            {
                models = await _modelRepository.GetPagination(start, limit);
            } catch (Exception e)
            {
                throw e;
            }
            return models;
        }

        public async Task<bool> RemoveModelAsync(string id)
        {
            bool isModelRemoved;
            try
            {
                isModelRemoved = await _modelRepository.Remove(id);
            } catch (Exception e)
            {
                throw e;
            }
            return isModelRemoved;
        }

        public async Task<Model> UpdateModelAsync(string id, Model model)
        {
            Model modelExisted = await GetByIdAsync(id);

            Model modelUpdated;

            if(modelExisted != null)
            {
                try
                {
                    model.setUpdatedAt(DateTime.UtcNow);
                    modelUpdated = await _modelRepository.Update(id, model);
                } catch (Exception e)
                {
                    throw e;
                }
            } else
            {
                return modelExisted;
            }
            return modelUpdated;
        }
    }
}
