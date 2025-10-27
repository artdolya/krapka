using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    /// <summary>
    /// Write operations for repositories (add or update).
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public interface IRepositoryWriter<TEntity> : IRepository
    {
        /// <summary>
        /// Add a new entity or update an existing one.
        /// The implementation is expected to attach and mark the entity for insert or update as appropriate.
        /// </summary>
        /// <param name="entity">Entity to add or update.</param>
        /// <returns>The same entity instance (may have been modified by the repository).</returns>
        TEntity AddOrUpdate(TEntity entity);

        /// <summary>
        /// Asynchronously add a new entity.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>A task that returns the added entity instance.</returns>
        Task<TEntity> AddAsync(TEntity entity);
    }
}