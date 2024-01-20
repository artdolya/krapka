using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryWriter<T> : IRepository
    {
        T AddOrUpdate(T entity);
    }

    public interface IAsyncRepositoryWriter<T> : IRepository
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}