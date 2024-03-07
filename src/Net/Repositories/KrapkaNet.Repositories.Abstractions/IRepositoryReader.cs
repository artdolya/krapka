﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryReader<T, in TKey> : IRepository
        where T : class, IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Find an entity by its id
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns>Entity</returns>
        T FindBy(TKey id);
        
        /// <summary>
        /// Find an entity by its id. If not found, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity or Null</returns>
        T GetBy(TKey id);
        
        /// <summary>
        /// Find an entity by its id. If not found, return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity or Null</returns>
        Task<T> GetByAsync(TKey id);

        /// <summary>
        /// Find entities by a filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>IQueryable collection of Entities.</returns>
        IQueryable<T> GetBy(Expression<Func<T, bool>> filter);
    }
}