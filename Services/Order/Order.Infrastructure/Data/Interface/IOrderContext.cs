using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.Core.Entities;

namespace Order.Infrastructure.Data.Interface
{
    public interface IOrderContext
    {
        DbSet<Core.Entities.Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        DbSet<ShippingDetails> ShippingDetails { get; set; }

        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
