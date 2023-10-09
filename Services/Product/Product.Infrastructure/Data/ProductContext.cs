using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Product.Core.Entities;
using Product.Infrastructure.Data.Interface;

namespace Product.Infrastructure.Data
{
    public class ProductContext : DbContext, IProductContext
    {
        public DbSet<Core.Entities.Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ItemImage> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
