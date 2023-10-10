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

        public DbSet<Core.Entities.Order> Products { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<OrderItem> Brands { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<OrderStatusHistory> Categories { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<ShippingDetails> Reviews { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
