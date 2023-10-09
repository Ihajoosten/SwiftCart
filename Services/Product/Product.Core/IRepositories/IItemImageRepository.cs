using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IItemImageRepository : IRepository<ItemImage>
    {
        Task<IEnumerable<ItemImage?>?> GetImagesByProductIdAsync(int productId);
    }
}
