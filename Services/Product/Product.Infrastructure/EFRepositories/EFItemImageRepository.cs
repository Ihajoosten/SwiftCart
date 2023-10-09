using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories.Base;

namespace Product.Infrastructure.EFRepositories
{
    public class EFItemImageRepository : EFRepository<ItemImage>, IItemImageRepository
    {
        public EFItemImageRepository(IProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ItemImage?>?> GetImagesByProductIdAsync(int productId)
        {
            var allImages = await GetAllAsync();
            var productImages = allImages.Where(i => i?.ProductId == productId);
            return productImages;
        }
    }
}
