namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryWriter<T> : IRepository
    {
        T AddOrUpdate(T entity);
    }
}