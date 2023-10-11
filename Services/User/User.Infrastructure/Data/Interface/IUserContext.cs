using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using User.Core.Entities;

namespace User.Infrastructure.Data.Interface
{
    public interface IUserContext
    {
        DbSet<Core.Entities.User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<PhoneNumber> PhoneNumbers { get; set; }

        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
