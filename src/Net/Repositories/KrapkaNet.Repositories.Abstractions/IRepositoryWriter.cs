using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryWriter<TEntity> : IRepository
    {
        /// <summary>
        /// Add or update an entity
        /// </summary>
        /// <param name="entity">Entity to be save</param>
        /// <returns>Saved Entity</returns>
        TEntity AddOrUpdate(TEntity entity);

        /// <summary>
        /// Add or update an entity
        /// </summary>
        /// <param name="entity">Entity to be save</param>
        /// <returns>Saved Entity</returns>
        Task<TEntity> AddAsync(TEntity entity);
    }
}