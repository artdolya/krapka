using System.Threading.Tasks;
using KrapkaNet.Data.Abstractions;

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
}