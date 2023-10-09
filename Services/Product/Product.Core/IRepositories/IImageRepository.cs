using Product.Core.Entities;
using Product.Core.IRepositories.Base;
using static System.Net.Mime.MediaTypeNames;

namespace Product.Core.IRepositories
{
    public interface IImageRepository : IRepository<ItemImage>
    {
        Task<IEnumerable<ItemImage>> GetImagesByProductIdAsync(int productId);
    }
}
