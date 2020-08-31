using IOT.Models.Entity;
using IOT.Repositories.Interface;
using IOT.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOT.Services.Service
{
    /// <summary>
    /// ObjectService
    /// </summary>
    /// <author>@HungDinh</author>
    public class ObjectService : IObjectService
    {
        private readonly IObjectRepository _objectRepository;

        public ObjectService(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }

        public async Task<Object> AddObjectAsync(Object obj)
        {
            return await _objectRepository.Add(obj);
        }

        public async Task<IEnumerable<Object>> GetAll()
        {
            return await _objectRepository.GetAll();
        }

        public async Task<Object> GetByIdAsync(string id)
        {
            return await _objectRepository.GetById(id);
        }

        public async Task<bool> RemoveObjectAsync(string id)
        {
            return await _objectRepository.Remove(id);
        }

        public async Task<Object> UpdateObjectAsync(string id, Object obj)
        {
            return await _objectRepository.Update(id, obj);
        }
    }
}
