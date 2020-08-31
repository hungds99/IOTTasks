using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Repositories
{
    /// <summary>
    /// IBaseRepository<TEntity>
    /// </summary>
    /// <author>@HungDinh</author>
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(string id, TEntity obj);
        Task<bool> Remove(string id);
    }
}
