using KrapkaNet.Data.Abstractions;
using System;
using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepository
    {
        bool Save();
        Task<bool> SaveAsync();
    }

    public interface IRepository<TEntity, in TKey> :
        IRepository, IRepositoryReader<TEntity, TKey>, IRepositoryWriter<TEntity>, IRepositoryRemover<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {

    }

    public interface IRepository<TEntity> : IRepository, IRepositoryReader<TEntity>, IRepositoryWriter<TEntity>, IRepositoryRemover<TEntity>
       where TEntity : class, IEntity<Guid>
    {
    }

    public interface IClassicRepository<TEntity> : IRepository, IClassicRepositoryReader<TEntity>, IRepositoryWriter<TEntity>, IClassicRepositoryRemover<TEntity>
       where TEntity : class, IEntity<int>
    {
    }
}