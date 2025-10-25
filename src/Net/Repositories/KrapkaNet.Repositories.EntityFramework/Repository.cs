using KrapkaNet.Data.Abstractions;
using KrapkaNet.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KrapkaNet.Repositories.EntityFramework
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        protected Repository(DbContext context)
        {
            _context = context;
        }

        private readonly DbContext _context;
        protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public TEntity FindBy(TKey id)
        {
            return DbSet.Find(id);
        }

        public TEntity GetBy(TKey id)
        {
            return DbSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<TEntity> GetByAsync(TKey id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
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

        public TEntity AddOrUpdate(TEntity entity)
        {
            if (entity.Id.Equals(default(TKey)))
                DbSet.Add(entity);
            else
                DbSet.Update(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
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

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }

    public class Repository<TEntity> : Repository<TEntity, Guid>, IRepository<TEntity>
        where TEntity : class, IEntity<Guid>
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {

        }
    }

    public class ClassicRepository<TEntity> : Repository<TEntity, int>, IClassicRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public ClassicRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
