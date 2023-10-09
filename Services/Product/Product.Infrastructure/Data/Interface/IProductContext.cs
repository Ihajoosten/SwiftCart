using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Product.Core.Entities;

namespace Product.Infrastructure.Data.Interface
{
    public interface IProductContext
    {
        DbSet<Core.Entities.Product> Products { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<ItemImage> Images { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ProductTag> ProductTags { get; set; }

        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
