using HealthcareSystem.Infrastructure.Abstracts;
using HealthcareSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Domain.Abstracts;

namespace HealthcareSystem.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork<TContext>
            where TContext : DbContext, new()
    {
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task<int> Save();
        IRepository<TEntity, TContext> GenericRepository<TEntity>() where TEntity : class, IBaseEntity, new();
    }
}
