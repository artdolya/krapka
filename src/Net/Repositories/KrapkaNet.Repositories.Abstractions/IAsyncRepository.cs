using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IAsyncRepository<T, in TKey> :
        IAsyncRepositoryReader<T, TKey>, IAsyncRepositoryWriter<T>, IAsyncRepositoryRemover<T, TKey>
        where T : class, IEntity<TKey>
        where TKey : struct
    {}
}