﻿using Auth.Core.IRepositories.Base;
using Auth.Infrastructure.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.EFRepositories.Base
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly IAuthContext _context;

        public EFRepository(IAuthContext productContext)
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

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
