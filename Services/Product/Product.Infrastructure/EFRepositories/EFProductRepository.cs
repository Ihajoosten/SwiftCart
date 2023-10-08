using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Core.Specs;
using Product.Infrastructure.Data;

namespace Product.Infrastructure.EFRepositories
{
    public class ProductRepository : IProductRepository, IBrandRepository, ITypeRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
    }
}
