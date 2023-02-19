using HealthcareSystem.Domain.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthcareSystem.Infrastructure.Abstracts
{
    public interface IRepository<TEntity, TContext>
         where TEntity : class, IBaseEntity, new()
         where TContext : DbContext, new()
    {
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IQueryable<TEntity>> Queryable();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = true);
        Task<TEntity> Add(TEntity entity);
        Task<int> AddRange(List<TEntity> entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(Guid id);
        Task<IQueryable<TEntity>> Queryable(Expression<Func<TEntity, bool>> filter);

    }
}
