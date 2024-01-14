namespace KrapkaNet.Repository.Abstractions;

public interface IRepositoryWriter<T> : IRepository
{
    T Add(T entity);
    T Update(T entity);
}

public interface IAsyncRepositoryWriter<T> : IRepository
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
}