using System.Linq.Expressions;

namespace FlockAPI.Data.Repository
{
    public interface IRepositoryAsync<T> where T : class
    {
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        void Update(object id, T entity);
    }
}
