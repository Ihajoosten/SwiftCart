using Product.Application.Dto.Brand;
using Product.Application.Interfaces.Base;

namespace Product.Application.Interfaces
{
    public interface IAppBrandService : IApplicationService<BrandDto, CreateBrandDto, UpdateBrandDto>
    {
        Task<IEnumerable<BrandDto?>?> GetPopularBrandsAsync(int count);
    }
}