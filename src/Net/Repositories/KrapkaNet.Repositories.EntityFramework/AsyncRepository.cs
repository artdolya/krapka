using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KrapkaNet.Data.Abstractions;
using KrapkaNet.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KrapkaNet.Repositories.EntityFramework
{
    public class AsyncRepository<T, TKey> : IAsyncRepository<T, TKey>
        where T : class, IEntity<TKey>
        where TKey : struct
    {
        private readonly DbContext _context;

        protected DbSet<T> DbSet { get; }
        
        protected AsyncRepository(DbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public async Task<T> GetByAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> expression)
        {
            return await DbSet.Where(expression).ToListAsync();
        }

        public Task<IEnumerable<TModel>> GetByAsync<TModel>(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}