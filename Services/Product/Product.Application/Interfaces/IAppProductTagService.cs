using Product.Application.Dto.Product;
using Product.Application.Dto.ProductTag;
using Product.Application.Dto.Tag;
using Product.Application.Interfaces.Base;

namespace Product.Application.Interfaces
{
    public interface IAppProductTagService : IApplicationService<ProductTagDto, CreateProductTagDto, UpdateProductTagDto>
    {
        Task<IEnumerable<ProductDto>> GetProductsByTagAsync(int tagId);
        Task<IEnumerable<TagDto>> GetTagsByProductAsync(int productId);
    }
}
