using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using User.Infrastructure.Data.Interface;
using User.Core.Entities;

namespace User.Infrastructure.Data
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext() { }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User.Core.Entities.User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

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
