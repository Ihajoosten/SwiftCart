using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;

namespace Product.Infrastructure.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Core.Entities.Product> Products{ get; set; }
        public DbSet<ProductBrand> ProductBrands{ get; set; }
        public DbSet<ProductType> ProductTypes { get; set; 
    }
}
