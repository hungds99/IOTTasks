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
            Object objectAdded;
            try
            {
                objectAdded = await _objectRepository.Add(obj);
            } catch (System.Exception e)
            {
                throw e;
            }

            return objectAdded;
        }

        public async Task<IEnumerable<Object>> GetAll()
        {
            return await _objectRepository.GetAll();
        }

        public async Task<Object> GetByIdAsync(string id)
        {
            Object obj;
            try
            {
                obj = await _objectRepository.GetById(id);
            } catch(System.Exception e)
            {
                throw e;
            }
            return obj;
        }

        public async Task<bool> RemoveObjectAsync(string id)
        {
            bool isObjectRemoved;
            try
            {
                isObjectRemoved = await _objectRepository.Remove(id);
            } catch (System.Exception e)
            {
                throw e;
            }
            return isObjectRemoved;
        }

        public async Task<Object> UpdateObjectAsync(string id, Object obj)
        {
            var objectExisted = await GetByIdAsync(id);
            Object objt;
            if(objectExisted != null)
            {
                try
                {
                    objt = await _objectRepository.Update(id, obj);
                } catch (System.Exception e)
                {
                    throw e;
                }
            } else
            {
                return objectExisted;
            }
            return objt;
        }
    }
}
