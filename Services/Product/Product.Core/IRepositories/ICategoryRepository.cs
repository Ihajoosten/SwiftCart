using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category?>?> GetMainCategoriesAsync();
    }
}
