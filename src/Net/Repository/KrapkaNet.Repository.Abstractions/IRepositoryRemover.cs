using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repository.Abstractions;

public interface IRepositoryRemover<in T, in TKey> : IRepository
    where T : class, IEntity<TKey>
{
    void Remove(TKey id);
    void Remove(T entity);
}

public interface IAsyncRepositoryRemover<in T, in TKey> : IRepository
    where T : class, IEntity<TKey>
{
    Task RemoveAsync(TKey id);
    Task RemoveAsync(T entity);
}