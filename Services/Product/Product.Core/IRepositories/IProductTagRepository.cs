using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
        Task<IEnumerable<Core.Entities.Product>> GetProductsByTagAsync(int tagId);
        Task<IEnumerable<Tag>> GetTagsByProductAsync(int productId);
    }
}
