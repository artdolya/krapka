using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repository.Abstractions;

public interface IRepository
{
}

public interface IRepository<T, in TKey> : IRepositoryReader<T, TKey>, IRepositoryWriter<T>, IRepositoryRemover<T, TKey>
    where T : class, IEntity<TKey>
{
}

public interface IAsyncRepository<T, in TKey> :
    IAsyncRepositoryReader<T, TKey>,
    IAsyncRepositoryWriter<T>,
    IAsyncRepositoryRemover<T, TKey>
    where T : class, IEntity<TKey>
{
}