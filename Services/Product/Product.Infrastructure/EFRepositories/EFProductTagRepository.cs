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

        public async Task<IEnumerable<ProductTag?>?> GetProductTagsByProductIdAsync(int productId)
        {
            var allProductTags = await GetAllAsync();
            var filteredTags = allProductTags.Where(pt => pt?.ProductId == productId).ToList();
            return filteredTags;
        }
    }
}
