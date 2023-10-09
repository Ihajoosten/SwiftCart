using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Application.Dto.Brand;
using Product.Application.Dto.Category;
using Product.Application.Dto.ItemImage;
using Product.Application.Dto.Product;
using Product.Application.Dto.ProductTag;
using Product.Application.Dto.Review;
using Product.Application.Dto.Tag;
using Product.Application.Interfaces;
using Product.Application.Services;
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
builder.Services.AddDbContext<IProductContext, ProductContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("LocalDevelopment")));

// Service Dependencies
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
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Product.Core.Entities.Product, ProductDto>();
    cfg.CreateMap<Brand, BrandDto>();
    cfg.CreateMap<Category, CategoryDto>();
    cfg.CreateMap<Review, ReviewDto>();
    cfg.CreateMap<ItemImage, ItemImageDto>();
    cfg.CreateMap<Tag, TagDto>();
    cfg.CreateMap<ProductTag, ProductTagDto>();
});

var mapper = mapperConfig.CreateMapper();
services.AddSingleton(mapper);

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
