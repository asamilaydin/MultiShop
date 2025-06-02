using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace MultiShop.Order.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OrderDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(OrderDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        // SaveChangesAsync genellikle UnitOfWork veya doğrudan DbContext üzerinden çağrılır.
        // Eğer repository seviyesinde istenirse:
        // public async Task<int> SaveChangesAsync()
        // {
        //     return await _context.SaveChangesAsync();
        // }
    }
} 