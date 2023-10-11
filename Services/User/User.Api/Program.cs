using AutoMapper;
using Microsoft.EntityFrameworkCore;
using User.Api.Mappings;
using User.Application.Dto.Address;
using User.Application.Dto.PhoneNumber;
using User.Application.Dto.User;
using User.Application.Interfaces;
using User.Application.Interfaces.Base;
using User.Application.Services;
using User.Application.Services.Base;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Core.IRepositories.Base;
using User.Infrastructure.Data;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories;
using User.Infrastructure.EFRepositories.Base;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;


// Database Dependencies
services.AddScoped<IUserContext, UserContext>();
services.AddDbContext<UserContext>(options => options.UseNpgsql(config.GetConnectionString("UserApiConnection")));


// Service Dependencies
services.AddTransient<IApplicationService<UserDto, CreateUserDto, UpdateUserDto>, ApplicationService<User.Core.Entities.User, UserDto, CreateUserDto, UpdateUserDto>>();
services.AddTransient<IApplicationService<AddressDto, CreateAddressDto, UpdateAddressDto>, ApplicationService<User.Core.Entities.Address, AddressDto, CreateAddressDto, UpdateAddressDto>>();
services.AddTransient<IApplicationService<PhoneNumberDto, CreatePhoneNumberDto, UpdatePhoneNumberDto>, ApplicationService<PhoneNumber, PhoneNumberDto, CreatePhoneNumberDto, UpdatePhoneNumberDto>>();

services.AddScoped<IAppUserService, AppUserService>();
services.AddScoped<IAppAddressService, AppAddressService>();
services.AddScoped<IAppPhoneNumberService, AppPhoneNumberService>();

// Repository Dependencies
services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
services.AddScoped<IUserRepository, EFUserRepository>();
services.AddScoped<IAddressRepository, EFAddressRepository>();
services.AddScoped<IPhoneNumberRepository, EFPhoneNumberRepository>();

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
