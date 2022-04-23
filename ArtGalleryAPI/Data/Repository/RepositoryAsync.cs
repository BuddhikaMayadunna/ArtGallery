using FlockAPI.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlockAPI.Data.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly IUnitOfWorkAsync unitOfWork;

        public RepositoryAsync(IUnitOfWorkAsync unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Delete(T entity)
        {
            if (entity != null) 
                unitOfWork.Context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await unitOfWork.Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = unitOfWork.Context.Set<T>();
            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await unitOfWork.Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public void Insert(T entity)
        {
            if (entity != null)
                unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Update(object id, T entity)
        {
            if (entity != null)
                unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
