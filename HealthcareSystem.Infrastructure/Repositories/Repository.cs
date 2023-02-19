using HealthcareSystem.Domain.Abstracts;
using HealthcareSystem.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthcareSystem.Infrastructure.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
            where TEntity : class, IBaseEntity, new()
            where TContext : DbContext, new()
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = true)
        {
            TEntity? entity = filter == null
            ? await _dbSet.FirstOrDefaultAsync()
                     : await _dbSet.Where(filter).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> entity = filter == null
            ? await _dbSet.ToListAsync()
                     : await _dbSet.Where(filter).ToListAsync();

            return entity;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<int> AddRange(List<TEntity> entity)
        {

            await _dbSet.AddRangeAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Count;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<TEntity> Delete(Guid id)
        {

            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<TEntity>> Queryable(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> entity = filter == null
           ? _dbSet.AsQueryable()
                    : _dbSet.Where(filter).AsQueryable();
            return await Task.FromResult(entity);
        }

        public async Task<IQueryable<TEntity>> Queryable()
        {

            return await Task.FromResult(_dbSet.AsQueryable());
        }
    }
}