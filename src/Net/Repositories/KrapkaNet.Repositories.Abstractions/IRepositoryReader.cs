﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryReader<T, in TKey> : IRepository
        where T : class, IEntity<TKey> where TKey : struct
    {
        T GetBy(TKey id);
        IEnumerable<T> GetBy(Expression<Func<T, bool>> filter);
    }
}