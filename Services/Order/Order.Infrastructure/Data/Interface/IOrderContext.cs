using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.Core.Entities;

namespace Order.Infrastructure.Data.Interface
{
    public interface IOrderContext
    {
        DbSet<Core.Entities.Order> Products { get; set; }
        DbSet<OrderItem> Brands { get; set; }
        DbSet<OrderStatusHistory> Categories { get; set; }
        DbSet<ShippingDetails> Reviews { get; set; }

        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
