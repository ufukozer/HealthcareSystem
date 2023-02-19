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
        //Here TContext is nothing but your DBContext class
        //In our example it is EmployeeDBContext class
        private readonly TContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private IDbContextTransaction _objTran;
        private Dictionary<string, object> _repositories;

        //Using the Constructor we are initializing the _context variable is nothing but
        //we are storing the DBContext (EmployeeDBContext) object in _context variable
        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        //The Dispose() method is used to free unmanaged resources like files, 
        //database connections etc. at any time.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //This Context property will return the DBContext object i.e. (EmployeeDBContext) object
        public TContext Context
        {
            get { return _context; }
        }

        //This CreateTransaction() method will create a database Trnasaction so that we can do database operations by
        //applying do evrything and do nothing principle
        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        //If all the Transactions are completed successfuly then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            _objTran.Commit();
        }

        //If atleast one of the Transaction is Failed then we need to call this Rollback() 
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        //This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
        //call this Save() method so that it will make the changes in the database
        public async Task<int> Save()
        {
            //try
            //{
            return await _context.SaveChangesAsync();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //            _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
            //    throw new Exception(_errorMessage, dbEx);
            //}
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
