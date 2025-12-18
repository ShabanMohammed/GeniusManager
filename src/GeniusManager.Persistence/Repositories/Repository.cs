using GeniusManager.Domain.Common;
using GeniusManager.Domain.Contracts.Repositories;
using GeniusManager.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace GeniusManager.Persistence.Repositories
{

    public class Repository<T> : IRepository<T> where T : BaseEntity,new()
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync( T entity)
        {
            
            await  _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var trackedEntity = _dbContext.Set<T>().Local.FirstOrDefault(e => e.Id == entity.Id);

            if (trackedEntity != null)
            {
                // إذا وجدنا نسخة مُتتبعة، نقوم بفصلها
                _dbContext.Entry(trackedEntity).State = EntityState.Detached;
            }
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e=> e.Id==id);
        }

        public async Task UpdateAsync(T entity)
        {
           var exists= await _dbSet.AnyAsync(e => e.Id != entity.Id && e.Name==entity.Name);
           if(exists)
            {
              throw new InvalidOperationException("هذا الاسم موجود مسبقاً.");
            }

            var trackedEntity = _dbContext.Set<T>().Local.FirstOrDefault(e => e.Id == entity.Id);

            if (trackedEntity != null)
            {
                // إذا وجدنا نسخة مُتتبعة، نقوم بفصلها
                _dbContext.Entry(trackedEntity).State = EntityState.Detached;
            }
           
            _dbSet.Update(entity);
            

            await _dbContext.SaveChangesAsync();
        }
    }
}