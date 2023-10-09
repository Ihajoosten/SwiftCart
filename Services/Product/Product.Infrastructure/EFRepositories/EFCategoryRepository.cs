using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories.Base;

namespace Product.Infrastructure.EFRepositories
{
    public class EFCategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(IProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category?>?> GetMainCategoriesAsync()
        {
            var allCategories = await GetAllAsync();
            var filteredCategories = allCategories.Where(x => x?.IsMainCategory == true);
            return filteredCategories;
        }
    }
}
