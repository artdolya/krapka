using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KrapkaNet.Data.Abstractions;
using KrapkaNet.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KrapkaNet.Repositories.EntityFramework
{
    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : class, IEntity<TKey>
        where TKey : struct
    {
        protected Repository(DbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        private readonly DbContext _context;

        protected DbSet<T> DbSet { get; }
  
        public T FindBy(TKey id)
        {
            return DbSet.Find(id);
        }
        
        public T GetBy(TKey id)
        {
            return DbSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<T> GetByAsync(TKey id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> filter)
        {
            return DbSet.Where(filter);
        }

        public bool Save()
        {
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public T AddOrUpdate(T entity)
        {
            if (entity.Id.Equals(default(TKey)))
                DbSet.Add(entity);
            else
                DbSet.Update(entity);
            return entity;
        }
        
        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }
        
        public void Remove(TKey id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

    }
}
