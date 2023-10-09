using AutoMapper;
using Product.Application.Dto.Brand;
using Product.Application.Interfaces;
using Product.Application.Services.Base;
using Product.Core.Entities;
using Product.Core.IRepositories;

namespace Product.Application.Services
{
    public class AppBrandService : ApplicationService<Brand, BrandDto, CreateBrandDto, UpdateBrandDto>, IAppBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public AppBrandService(IBrandRepository brandRepository, IMapper mapper)
            : base(brandRepository, mapper)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }

        public async Task<IEnumerable<BrandDto>> GetPopularBrandsAsync(int count)
        {
            var popularBrands = await _brandRepository.GetPopularBrandsAsync(count);
            return _mapper.Map<IEnumerable<BrandDto>>(popularBrands);
        }
    }
}
