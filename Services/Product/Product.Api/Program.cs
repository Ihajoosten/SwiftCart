using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Api.Mappings;
using Product.Application.Dto.Brand;
using Product.Application.Dto.Category;
using Product.Application.Dto.ItemImage;
using Product.Application.Dto.Product;
using Product.Application.Dto.ProductTag;
using Product.Application.Dto.Review;
using Product.Application.Dto.Tag;
using Product.Application.Interfaces;
using Product.Application.Interfaces.Base;
using Product.Application.Services;
using Product.Application.Services.Base;
using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Core.IRepositories.Base;
using Product.Infrastructure.Data;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories;
using Product.Infrastructure.EFRepositories.Base;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;


// Database Dependencies
services.AddScoped<IProductContext, ProductContext>();
services.AddDbContext<ProductContext>(options => options.UseNpgsql(config.GetConnectionString("ProductApiConnection")));


// Service Dependencies
services.AddTransient<IApplicationService<ProductDto, CreateProductDto, UpdateProductDto>, ApplicationService<Product.Core.Entities.Product, ProductDto, CreateProductDto, UpdateProductDto>>();
services.AddTransient<IApplicationService<BrandDto, CreateBrandDto, UpdateBrandDto>, ApplicationService<Brand, BrandDto, CreateBrandDto, UpdateBrandDto>>();
services.AddTransient<IApplicationService<CategoryDto, CreateCategoryDto, UpdateCategoryDto>, ApplicationService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>>();
services.AddTransient<IApplicationService<ReviewDto, CreateReviewDto, UpdateReviewDto>, ApplicationService<Review, ReviewDto, CreateReviewDto, UpdateReviewDto>>();
services.AddTransient<IApplicationService<ItemImageDto, CreateItemImageDto, UpdateItemImageDto>, ApplicationService<ItemImage, ItemImageDto, CreateItemImageDto, UpdateItemImageDto>>();
services.AddTransient<IApplicationService<TagDto, CreateTagDto, UpdateTagDto>, ApplicationService<Tag, TagDto, CreateTagDto, UpdateTagDto>>();
services.AddTransient<IApplicationService<ProductTagDto, CreateProductTagDto, UpdateProductTagDto>, ApplicationService<ProductTag, ProductTagDto, CreateProductTagDto, UpdateProductTagDto>>();

services.AddScoped<IAppProductService, AppProductService>();
services.AddScoped<IAppBrandService, AppBrandService>();
services.AddScoped<IAppCategoryService, AppCategoryService>();
services.AddScoped<IAppReviewService, AppReviewService>();
services.AddScoped<IAppItemImageService, AppItemImageService>();
services.AddScoped<IAppTagService, AppTagService>();
services.AddScoped<IAppProductTagService, AppProductTagService>();

// Repository Dependencies
services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
services.AddScoped<IProductRepository, EFProductRepository>();
services.AddScoped<IBrandRepository, EFBrandRepository>();
services.AddScoped<ICategoryRepository, EFCategoryRepository>();
services.AddScoped<IReviewRepository, EFReviewRepository>();
services.AddScoped<IItemImageRepository, EFItemImageRepository>();
services.AddScoped<ITagRepository, EFTagRepository>();
services.AddScoped<IProductTagRepository, EFProductTagRepository>();

// Configuration Mapper Entity <> Dto
services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<DtoMappingProfile>();
    cfg.AddProfile<CreateDtoMappingProfile>();
    cfg.AddProfile<UpdateDtoMappingProfile>();
});

services.AddSingleton(serviceProvider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile<DtoMappingProfile>();
    cfg.AddProfile<CreateDtoMappingProfile>();
    cfg.AddProfile<UpdateDtoMappingProfile>();
}).CreateMapper());

// Add services to the container.
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();