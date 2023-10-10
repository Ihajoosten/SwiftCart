using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.Core.Entities;
using Order.Infrastructure.Data.Interface;

namespace Order.Infrastructure.Data
{
    public class OrderContext : DbContext, IOrderContext
    {
        public OrderContext() { }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Core.Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }

        public override DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
