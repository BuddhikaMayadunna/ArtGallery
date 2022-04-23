using ArtGalleryAPI.Data;
using FlockAPI.Data.Repository;

namespace FlockAPI.Data.UnitOfWork
{
    public class UnitOfWorkAsync : IUnitOfWorkAsync
    {
        public DataContext Context { get; }

        private bool disposed;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkAsync"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWorkAsync(DataContext context)
        {
            Context = context;
            disposed = false;
        }

        /// <summary>
        /// The repositories asynchronous.
        /// </summary>
        private Dictionary<Type, object> repositoriesAsync;

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            if (repositoriesAsync == null) repositoriesAsync = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!repositoriesAsync.ContainsKey(type)) repositoriesAsync[type] = new RepositoryAsync<TEntity>(this);
            return (IRepositoryAsync<TEntity>)repositoriesAsync[type];
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await Context.SaveAsync();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool isDisposing)
        {
            if (!disposed && isDisposing)
                Context.Dispose();
            disposed = true;
        }
    }
}
