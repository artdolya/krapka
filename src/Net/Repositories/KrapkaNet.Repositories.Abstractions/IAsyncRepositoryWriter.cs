using System.Threading.Tasks;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IAsyncRepositoryWriter<T> : IRepository
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}