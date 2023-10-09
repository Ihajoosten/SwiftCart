using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IImageRepository : IRepository<ItemImage>
    {
        Task<IEnumerable<ItemImage?>?> GetImagesByProductIdAsync(int productId);
    }
}
