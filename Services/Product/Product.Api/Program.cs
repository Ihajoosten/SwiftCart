using Product.Core.IRepositories;
using Product.Core.IRepositories.Base;
using Product.Infrastructure.EFRepositories;
using Product.Infrastructure.EFRepositories.Base;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuraiton = builder.Configuration;

// Add services to the container.
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

// Register your repositories
services.AddScoped<IProductRepository, EFProductRepository>();
services.AddScoped<IBrandRepository, EFBrandRepository>();

//services.AddScoped<ICategoryRepository, EFCategoryRepository>();
//services.AddScoped<IReviewRepository, EFReviewRepository>();
//services.AddScoped<IImageRepository, EFImageRepository>();
//services.AddScoped<ITagRepository, EFTagRepository>();
//services.AddScoped<IProductTagRepository, EFProductTagRepository>();

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
