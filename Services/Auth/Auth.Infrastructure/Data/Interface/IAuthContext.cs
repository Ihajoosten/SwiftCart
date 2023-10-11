using Auth.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Auth.Infrastructure.Data.Interface
{
    public interface IAuthContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Token> Tokens { get; set; }

        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
