using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
        Task<IEnumerable<ProductTag?>?> GetProductTagsByProductIdAsync(int productId);
    }
}
