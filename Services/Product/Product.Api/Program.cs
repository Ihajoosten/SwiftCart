using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Core.IRepositories.Base;
using Product.Infrastructure.EFRepositories;
using Product.Infrastructure.EFRepositories.Base;
using Product.Application.Interfaces;
using Product.Application.Interfaces.Base;
using Product.Application.Services;
using Product.Application.Services.Base;
using Product.Application.Dto.Brand;
using Product.Application.Dto.Product;
using Product.Application.Dto.Category;

using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuraiton = builder.Configuration;

// Add services to the container.
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Register Services
services.AddScoped(typeof(IApplicationService<,,>), typeof(ApplicationService<,,,>));
services.AddScoped<IAppProductService, AppProductService>();
services.AddScoped<IAppBrandService, AppBrandService>();
services.AddScoped<IAppCategoryService, AppCategoryService>();

// Register Repositories
services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
services.AddScoped<IProductRepository, EFProductRepository>();
services.AddScoped<IBrandRepository, EFBrandRepository>();
services.AddScoped<ICategoryRepository, EFCategoryRepository>();
services.AddScoped<IReviewRepository, EFReviewRepository>();
services.AddScoped<IImageRepository, EFImageRepository>();
services.AddScoped<ITagRepository, EFTagRepository>();
services.AddScoped<IProductTagRepository, EFProductTagRepository>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Product.Core.Entities.Product, ProductDto>();
    cfg.CreateMap<Brand, BrandDto>();
    cfg.CreateMap<Category, CategoryDto>();
});

var mapper = mapperConfig.CreateMapper();
services.AddSingleton(mapper);

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
