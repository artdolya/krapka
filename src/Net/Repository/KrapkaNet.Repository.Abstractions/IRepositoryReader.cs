﻿using System.Linq.Expressions;
using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repository.Abstractions;

public interface IRepositoryReader<out T, in TKey> : IRepository
    where T : class, IEntity<TKey> where TKey : struct
{
    T GetById(TKey id);
}

public interface IAsyncRepositoryReader<T, in TKey> : IRepository
    where T : class, IEntity<TKey> where TKey : struct
{
    Task<T> GetByIdAsync(TKey id);
    Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> expression);
}