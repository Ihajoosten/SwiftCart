using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories.Base;

namespace Product.Infrastructure.EFRepositories
{
    public class EFBrandRepository : EFRepository<Brand>, IBrandRepository
    {
        public EFBrandRepository(IProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Brand?>?> GetPopularBrandsAsync(int count)
        {
            
            var allBrands = await GetAllAsync();
            var filteredBrands = allBrands.OrderByDescending(x => x?.Products.Count).Take(count);
            return filteredBrands;
        }
    }
}
