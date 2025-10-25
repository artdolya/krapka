﻿using KrapkaNet.Data.Abstractions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryReader<TEntity, in TKey> : IRepository
        where TEntity : class, IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Find an entity by its id
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>Entity</returns>
        TEntity FindBy(TKey id);

        /// <summary>
        /// Find an entity by its id. If not found, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity or Null</returns>
        TEntity GetBy(TKey id);

        /// <summary>
        /// Find an entity by its id. If not found, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity or Null</returns>
        Task<TEntity> GetByAsync(TKey id);

        /// <summary>
        /// Find entities by a filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>IQueryable collection of Entities.</returns>
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);
    }

    public interface IRepositoryReader<T> : IRepositoryReader<T, Guid>
    where T : class, IEntity<Guid>, IEntity<int>
    {
    }

    public interface IClassicRepositoryReader<T> : IRepositoryReader<T, int>
    where T : class, IEntity<int>
    {
    }
}