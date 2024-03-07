using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryWriter<T> : IRepository
    {
        /// <summary>
        /// Add or update an entity
        /// </summary>
        /// <param name="entity">Entity to be save</param>
        /// <returns>Saved Entity</returns>
        T AddOrUpdate(T entity);
        
        /// <summary>
        /// Add or update an entity
        /// </summary>
        /// <param name="entity">Entity to be save</param>
        /// <returns>Saved Entity</returns>
        Task<T> AddAsync(T entity);
    }
}