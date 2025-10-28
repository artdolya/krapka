using KrapkaNet.Data.Abstractions;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    /// <summary>
    /// Read-only repository operations for an entity with key <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    /// <typeparam name="TKey">Entity key type (struct).</typeparam>
    public interface IRepositoryReader<TEntity, in TKey> : IRepository
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        /// <summary>
        /// Find an entity by its id without using includes.
        /// </summary>
        /// <param name="id">Primary key value.</param>
        /// <returns>The entity instance if found; otherwise null.</returns>
        TEntity FindBy(TKey id);

        /// <summary>
        /// Asynchronously find an entity by its id without using includes.
        /// </summary>
        /// <param name="id">Primary key value.</param>
        /// <returns>A task that returns the entity instance if found; otherwise null.</returns>
        Task<TEntity> FindByAsync(TKey id);

        /// <summary>
        /// Get an entity by its id using includes by default.
        /// </summary>
        /// <param name="id">Primary key value.</param>
        /// <returns>The entity instance if found; otherwise null.</returns>
        TEntity GetBy(TKey id);

        /// <summary>
        /// Asynchronously get an entity by its id using includes by default.
        /// </summary>
        /// <param name="id">Primary key value.</param>
        /// <returns>A task that returns the entity instance if found; otherwise null.</returns>
        Task<TEntity> GetByAsync(TKey id);

        /// <summary>
        /// Query entities that match the provided filter.
        /// </summary>
        /// <param name="filter">LINQ expression used to filter entities.</param>
        /// <returns>An <see cref="IQueryable{T}"/> that can be further composed or materialized.</returns>
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);
    }

    /// <summary>
    /// Reader convenience interface for entities keyed by <see cref="Guid"/>.
    /// </summary>
    /// <typeparam name="TEntity">Entity type (must implement <see cref="IEntity{Guid}"/>).</typeparam>
    public interface IRepositoryReader<TEntity> : IRepositoryReader<TEntity, Guid>
    where TEntity : class, IEntity<Guid>
    {
    }

    /// <summary>
    /// Reader convenience interface for classic int-keyed entities.
    /// </summary>
    /// <typeparam name="TEntity">Entity type (must implement <see cref="IEntity{int}"/>).</typeparam>
    public interface IClassicRepositoryReader<TEntity> : IRepositoryReader<TEntity, int>
    where TEntity : class, IEntity<int>
    {
    }
}