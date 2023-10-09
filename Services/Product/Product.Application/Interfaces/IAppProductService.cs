using Product.Application.Dto.Product;
using Product.Application.Interfaces.Base;

namespace Product.Application.Interfaces
{
    public interface IAppProductService : IApplicationService<ProductDto, CreateProductDto, UpdateProductDto>
    {
        /*
          Task<IEnumerable<ProductDto>> GetProductsByBrandAsync(int brandId);
          Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
          Task<IEnumerable<ProductDto>> GetProductsByTagAsync(int tagId);
          Task<IEnumerable<ProductDto>> GetProductsByRatingAsync(int minRating);
        */
        Task<IEnumerable<ProductDto>> GetTopSellingProductsAsync(int count);
        Task<IEnumerable<ProductDto>> GetNewArrivalProductsAsync(int count);
    }
}
