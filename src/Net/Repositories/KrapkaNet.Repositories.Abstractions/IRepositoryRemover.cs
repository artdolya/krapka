using KrapkaNet.Data.Abstractions;
using System;

namespace KrapkaNet.Repositories.Abstractions
{
    /// <summary>
    /// Remove operations for repositories for an entity keyed by <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    /// <typeparam name="TKey">Entity key type (struct).</typeparam>
    public interface IRepositoryRemover<in TEntity, in TKey> : IRepository
        where TEntity : class, IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Removes an entity by its id from the repository.
        /// </summary>
        /// <param name="id">Primary key of the entity to remove.</param>
        void Remove(TKey id);

        /// <summary>
        /// Removes an entity instance from the repository.
        /// </summary>
        /// <param name="entity">Entity instance to remove.</param>
        void Remove(TEntity entity);
    }

    /// <summary>
    /// Remover convenience interface for entities keyed by <see cref="Guid"/>.
    /// </summary>
    /// <typeparam name="TEntity">Entity type (must implement <see cref="IEntity{Guid}"/>).</typeparam>
    public interface IRepositoryRemover<TEntity> : IRepositoryRemover<TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
    }

    /// <summary>
    /// Remover convenience interface for classic int-keyed entities.
    /// </summary>
    /// <typeparam name="TEntity">Entity type (must implement <see cref="IEntity{int}"/>).</typeparam>
    public interface IClassicRepositoryRemover<TEntity> : IRepositoryRemover<TEntity, int>
        where TEntity : class, IEntity<int>
    {
    }
}