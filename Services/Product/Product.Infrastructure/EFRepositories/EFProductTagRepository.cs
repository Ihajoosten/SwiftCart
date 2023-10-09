using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories.Base;

namespace Product.Infrastructure.EFRepositories
{
    public class EFProductTagRepository : EFRepository<ProductTag>, IProductTagRepository
    {
        public EFProductTagRepository(IProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Core.Entities.Product>> GetProductsByTagAsync(int tagId)
        {
            return await _context.ProductTags
                .Where(pt => pt.TagId == tagId)
                .Select(pt => pt.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tag>> GetTagsByProductAsync(int productId)
        {
            return await _context.ProductTags
                .Where(pt => pt.ProductId == productId)
                .Select(pt => pt.Tag)
                .ToListAsync();
        }
    }
}
