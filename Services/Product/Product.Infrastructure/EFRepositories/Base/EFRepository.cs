using Microsoft.EntityFrameworkCore;
using Product.Core.IRepositories.Base;
using Product.Infrastructure.Data.Interface;

namespace Product.Infrastructure.EFRepositories.Base
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly IProductContext _context;

        public EFRepository(IProductContext productContext)
        {
            _context = productContext ?? throw new ArgumentNullException(nameof(productContext));
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
