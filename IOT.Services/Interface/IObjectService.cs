﻿using IOT.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOT.Services.Interface
{
    /// <summary>
    /// IObjectService
    /// </summary>
    /// <author>@HungDinh</author>
    public interface IObjectService
    {
        Task<Object> AddObjectAsync(Object obj);
        Task<Object> UpdateObjectAsync(string id, Object obj);
        Task<bool> RemoveObjectAsync(string id);
        Task<Object> GetByIdAsync(string id);
        Task<IEnumerable<Object>> GetAll();
    }
}