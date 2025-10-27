using KrapkaNet.Data.Abstractions;
using System;
using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    /// <summary>
    /// Base repository operations for transaction commit.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Persists pending changes synchronously.
        /// </summary>
        /// <returns>True when save succeeded.</returns>
        bool Save();

        /// <summary>
        /// Persists pending changes asynchronously.
        /// </summary>
        /// <returns>A task representing the save operation; task result is true when save succeeded.</returns>
        Task<bool> SaveAsync();
    }

    /// <summary>
    /// Generic repository that groups reader, writer and remover capabilities for an entity with key <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    /// <typeparam name="TKey">Entity key type (struct).</typeparam>
    public interface IRepository<TEntity, in TKey> :
        IRepository, IRepositoryReader<TEntity, TKey>, IRepositoryWriter<TEntity>, IRepositoryRemover<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {

    }

    /// <summary>
    /// Convenience repository interface for entities keyed by <see cref="Guid"/>.
    /// Combines reader, writer and remover functionality.
    /// </summary>
    /// <typeparam name="TEntity">Entity type (must implement <see cref="IEntity{Guid}"/>).</typeparam>
    public interface IRepository<TEntity> : IRepository, IRepositoryReader<TEntity>, IRepositoryWriter<TEntity>, IRepositoryRemover<TEntity>
       where TEntity : class, IEntity<Guid>
    {
    }

    /// <summary>
    /// Convenience repository interface for classic int-keyed entities.
    /// Combines reader, writer and remover functionality.
    /// </summary>
    /// <typeparam name="TEntity">Entity type (must implement <see cref="IEntity{int}"/>).</typeparam>
    public interface IClassicRepository<TEntity> : IRepository, IClassicRepositoryReader<TEntity>, IRepositoryWriter<TEntity>, IClassicRepositoryRemover<TEntity>
       where TEntity : class, IEntity<int>
    {
    }
}