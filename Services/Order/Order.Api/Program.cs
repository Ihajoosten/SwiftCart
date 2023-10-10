using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Api.Mappings;
using Order.Application.Dto.Order;
using Order.Application.Dto.OrderItem;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Dto.ShippingDetails;
using Order.Application.Interfaces;
using Order.Application.Interfaces.Base;
using Order.Application.Services;
using Order.Application.Services.Base;
using Order.Core.Entities;
using Order.Core.IRepositories;
using Order.Core.IRepositories.Base;
using Order.Infrastructure.Data;
using Order.Infrastructure.Data.Interface;
using Order.Infrastructure.EFRepositories;
using Order.Infrastructure.EFRepositories.Base;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;


// Database Dependencies
services.AddScoped<IOrderContext, OrderContext>();
services.AddDbContext<OrderContext>(options => options.UseNpgsql(config.GetConnectionString("OrderApiConnection")));

// Service Dependencies
services.AddTransient<IApplicationService<OrderDto, CreateOrderDto, UpdateOrderDto>, ApplicationService<Order.Core.Entities.Order, OrderDto, CreateOrderDto, UpdateOrderDto>>();
services.AddTransient<IApplicationService<OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>, ApplicationService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>>();
services.AddTransient<IApplicationService<OrderStatusHistoryDto, CreateOrderStatusHistoryDto, UpdateOrderStatusHistoryDto>, ApplicationService<OrderStatusHistory, OrderStatusHistoryDto, CreateOrderStatusHistoryDto, UpdateOrderStatusHistoryDto>>();
services.AddTransient<IApplicationService<ShippingDetailsDto, CreateShippingDetailsDto, UpdateShippingDetailsDto>, ApplicationService<ShippingDetails, ShippingDetailsDto, CreateShippingDetailsDto, UpdateShippingDetailsDto>>();

services.AddScoped<IAppOrderService, AppOrderService>();
services.AddScoped<IAppOrderItemService, AppOrderItemService>();
services.AddScoped<IAppOrderStatusHistoryService, AppOrderStatusHistoryService>();
services.AddScoped<IAppShippingDetailsService, AppShippingDetailsService>();

// Repository Dependencies
services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
services.AddScoped<IOrderRepository, EFOrderRepository>();
services.AddScoped<IOrderItemRepository, EFOrderItemRepository>();
services.AddScoped<IOrderStatusHistoryRepository, EFOrderStatusHistoryRepository>();
services.AddScoped<IShippingDetailsRepository, EFShippingDetailsRepository>();

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