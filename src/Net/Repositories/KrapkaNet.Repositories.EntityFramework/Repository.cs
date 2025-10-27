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

        public virtual TEntity FindBy(TKey id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity GetBy(TKey id)
        {
            return DbSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity> GetByAsync(TKey id)
        {
            return await BuildQueryWithIncludes().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
            return BuildQueryWithIncludes().Where(filter);
        }

        public virtual bool Save()
        {
            _context.SaveChanges();
            return true;
        }

        public virtual async Task<bool> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual TEntity AddOrUpdate(TEntity entity)
        {
            if (entity.Id.Equals(default(TKey)))
                DbSet.Add(entity);
            else
                DbSet.Update(entity);
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public virtual void Remove(TKey id)
        {
            var entity = DbSet.Find(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        protected IQueryable<TEntity> BuildQueryWithIncludes()
        {
            IQueryable<TEntity> query = DbSet.AsQueryable();

            var entityType = _context.Model.FindEntityType(typeof(TEntity));
            if (entityType == null)
                return query;

            // Include all navigations discovered in the EF model
            foreach (var navigation in entityType.GetNavigations())
            {
                // Use string-based Include to keep code simple and compatible across EF Core versions
                query = query.Include(navigation.Name);
            }

            return query;
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
