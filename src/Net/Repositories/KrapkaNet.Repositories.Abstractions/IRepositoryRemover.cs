using System.Threading.Tasks;
using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryRemover<in T, in TKey> : IRepository
        where T : class, IEntity<TKey> where TKey : struct
    {
        void Remove(TKey id);
        void Remove(T entity);
    }

    public interface IAsyncRepositoryRemover<in T, in TKey> : IRepository
        where T : class, IEntity<TKey> where TKey : struct
    {
        Task RemoveAsync(TKey id);
        Task RemoveAsync(T entity);
    }
}