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
    public class UpdateDtoMappingProfile : Profile
    {
        public UpdateDtoMappingProfile()
        {
            CreateMap<UpdateProductDto, Core.Entities.Product>();
            CreateMap<UpdateBrandDto, Brand>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<UpdateReviewDto, Review>();
            CreateMap<UpdateItemImageDto, ItemImage>();
            CreateMap<UpdateTagDto, Tag>();
            CreateMap<UpdateProductTagDto, ProductTag>();
        }
    }
}

