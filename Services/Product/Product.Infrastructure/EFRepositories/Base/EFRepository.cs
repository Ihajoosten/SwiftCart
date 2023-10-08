using Microsoft.EntityFrameworkCore;
using Product.Core.IRepositories.Base;
using Product.Core.Specs;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.EFRepositories.Base
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly ProductContext _context;

        public EFRepository(ProductContext movieContext)
        {
            _context = movieContext;
        }

        public async Task<IReadOnlyList<T?>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
