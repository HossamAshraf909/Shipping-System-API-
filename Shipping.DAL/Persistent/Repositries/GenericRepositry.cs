using Microsoft.EntityFrameworkCore;
using Shipping.DAL.Persistent.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shipping.DAL.Persistent.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ShippingContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ShippingContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<(IEnumerable<T> Data, int TotalRecords, int TotalPages)> GetPaginatedAsync(int page, int pageSize)
        {
            var totalRecords = await _dbSet.CountAsync();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var paginatedData = await _dbSet
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (paginatedData, totalRecords, totalPages);
        }


        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null) 
            { 

                entity.GetType().GetProperty("IsDeleted")?.SetValue(entity, true);
                _dbSet.Update(entity);

                await _context.SaveChangesAsync(); 
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
