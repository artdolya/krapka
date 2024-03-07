using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.Abstractions
{
    public interface IRepositoryRemover<in T, in TKey> : IRepository
        where T : class, IEntity<TKey> where TKey : struct
    {
        /// <summary>
        /// Removes an entity by its id from the repository
        /// </summary>
        /// <param name="id"></param>
        void Remove(TKey id);
        
        /// <summary>
        /// Removes an entity from the repository
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
    }
}