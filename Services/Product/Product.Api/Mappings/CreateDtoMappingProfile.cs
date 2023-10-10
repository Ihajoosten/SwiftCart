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
    public class CreateDtoMappingProfile : Profile
    {
        public CreateDtoMappingProfile()
        {
            CreateMap<CreateProductDto, Core.Entities.Product>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateReviewDto, Review>();
            CreateMap<CreateItemImageDto, ItemImage>();
            CreateMap<CreateTagDto, Tag>();
            CreateMap<CreateProductTagDto, ProductTag>();
        }
    }
}

