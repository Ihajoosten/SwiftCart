using Product.Application.Dto.ItemImage;
using Product.Application.Interfaces.Base;

namespace Product.Application.Interfaces
{
    public interface IAppItemImageService : IApplicationService<ItemImageDto, CreateItemImageDto, UpdateItemImageDto>
    {
        Task<IEnumerable<ItemImageDto?>?> GetImagesByProductIdAsync(int productId);
    }
}
