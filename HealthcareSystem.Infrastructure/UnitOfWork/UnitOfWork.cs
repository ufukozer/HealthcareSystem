using HealthcareSystem.Domain.Abstracts;
using HealthcareSystem.Infrastructure.Repositories;
using HealthcareSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Infrastructure.Abstracts;

namespace HealthcareSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
      where TContext : DbContext, new()
    {

        private readonly TContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private IDbContextTransaction _objTran;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public TContext Context
        {
            get { return _context; }
        }


        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }


        public void Commit()
        {
            _objTran.Commit();
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }


        public IRepository<TEntity, TContext> GenericRepository<TEntity>() where TEntity : class, IBaseEntity, new()
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<TEntity, TContext>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TContext)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<TEntity, TContext>)_repositories[type];
        }
    }
}
