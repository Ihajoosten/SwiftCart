using AutoMapper;
using Product.Application.Dto.ItemImage;
using Product.Application.Interfaces;
using Product.Application.Services.Base;
using Product.Core.Entities;
using Product.Core.IRepositories;

namespace Product.Application.Services
{
    public class AppItemImageService : ApplicationService<ItemImage, ItemImageDto, CreateItemImageDto, UpdateItemImageDto>, IAppItemImageService
    {
        private readonly IItemImageRepository _itemImageRepository;

        public AppItemImageService(IItemImageRepository itemImageRepository, IMapper mapper)
            : base(itemImageRepository, mapper)
        {
            _itemImageRepository = itemImageRepository ?? throw new ArgumentNullException(nameof(itemImageRepository));
        }

        public async Task<IEnumerable<ItemImageDto?>?> GetImagesByProductIdAsync(int productId)
        {
            var images = await _itemImageRepository.GetImagesByProductIdAsync(productId);
            return _mapper.Map<IEnumerable<ItemImageDto>>(images);
        }
    }
}
