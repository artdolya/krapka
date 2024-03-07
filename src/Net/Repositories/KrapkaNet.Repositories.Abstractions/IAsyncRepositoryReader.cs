using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IAsyncRepositoryReader<T, in TKey> : IRepository
        where T : class, IEntity<TKey> where TKey : struct
    {
        Task<T> GetByAsync(TKey id);
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> filter);
    }
}