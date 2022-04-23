using ArtGalleryAPI.Data;
using FlockAPI.Data.Repository;

namespace FlockAPI.Data.UnitOfWork
{
    public interface IUnitOfWorkAsync
    {
        /// <summary>
        /// Gets the repository asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        DataContext Context { get; }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns>Saved count.</returns>
        Task<int> SaveAsync();
    }
}
