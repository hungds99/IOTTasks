using IOT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOT.Services.Interface
{
    /// <summary>
    /// IModelService
    /// </summary>
    /// <author>@HungDinh</author>
    public interface IModelService
    {
        Task<Model> AddModelAsync(Model model);
        Task<IEnumerable<Model>> AddManyModelsAsync(IEnumerable<Model> models);
        Task<Model> UpdateModelAsync(string id, Model model);
        Task<bool> RemoveModelAsync(string id);
        Task<Model> GetByIdAsync(string id);
        Task<IEnumerable<Model>> GetAll();
        Task<IEnumerable<Model>> GetModelPaginationAsync(int start, int limit);
    }
}
