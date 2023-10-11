using Auth.Core.Entities;
using Auth.Infrastructure.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Auth.Infrastructure.Data
{
    public class AuthContext : DbContext, IAuthContext
    {
        public AuthContext() { }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public override DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
