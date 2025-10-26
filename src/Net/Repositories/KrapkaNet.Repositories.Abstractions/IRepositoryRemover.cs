using KrapkaNet.Data.Abstractions;
using System;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryRemover<in TEntity, in TKey> : IRepository
        where TEntity : class, IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Removes an entity by its id from the repository
        /// </summary>
        /// <param name="id"></param>
        void Remove(TKey id);

        /// <summary>
        /// Removes an entity from the repository
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
    }
    public interface IRepositoryRemover<TEntity> : IRepositoryRemover<TEntity, Guid>
        where TEntity : class, IEntity<Guid>
    {
    }

    public interface IClassicRepositoryRemover<TEntity> : IRepositoryRemover<TEntity, int>
        where TEntity : class, IEntity<int>
    {
    }
}