using KrapkaNet.Data.Abstractions;
using System;
using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepository
    {
    }

    public interface IRepository<T, in TKey> :
        IRepositoryReader<T, TKey>, IRepositoryWriter<T>, IRepositoryRemover<T, TKey>
        where T : class, IEntity<TKey> where TKey : struct
    {
        bool Save();

        Task<bool> SaveAsync();
    }

    public interface IRepository<T> :
       IRepository<T, Guid>
       where T : class, IEntity<Guid>
    {
    }

    public interface IClassicRepository<T> :
       IRepository<T, Guid>
       where T : class, IEntity<Guid>
    {
    }
}