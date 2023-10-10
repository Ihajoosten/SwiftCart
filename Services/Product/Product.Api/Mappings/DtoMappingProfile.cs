using AutoMapper;
using Product.Application.Dto.Brand;
using Product.Application.Dto.Category;
using Product.Application.Dto.ItemImage;
using Product.Application.Dto.Product;
using Product.Application.Dto.ProductTag;
using Product.Application.Dto.Review;
using Product.Application.Dto.Tag;
using Product.Core.Entities;

namespace Product.Api.Mappings
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Core.Entities.Product, ProductDto>();
            CreateMap<Brand, BrandDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ItemImage, ItemImageDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<ProductTag, ProductTagDto>();
        }
    }
}

