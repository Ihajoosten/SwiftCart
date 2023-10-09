using AutoMapper;
using Product.Application.Dto.Product;
using Product.Application.Dto.ProductTag;
using Product.Application.Dto.Tag;
using Product.Application.Interfaces;
using Product.Application.Services.Base;
using Product.Core.Entities;
using Product.Core.IRepositories;

namespace Product.Application.Services
{
    public class AppProductTagService : ApplicationService<ProductTag, ProductTagDto, CreateProductTagDto, UpdateProductTagDto>, IAppProductTagService
    {
        private readonly IProductTagRepository _productTagRepository;

        public AppProductTagService(IProductTagRepository productTagRepository, IMapper mapper)
            : base(productTagRepository, mapper)
        {
            _productTagRepository = productTagRepository ?? throw new ArgumentNullException(nameof(productTagRepository));
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByTagAsync(int tagId)
        {
            var products = await _productTagRepository.GetProductsByTagAsync(tagId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<TagDto>> GetTagsByProductAsync(int productId)
        {
            var tags = await _productTagRepository.GetTagsByProductAsync(productId);
            return _mapper.Map<IEnumerable<TagDto>>(tags);
        }
    }
}
