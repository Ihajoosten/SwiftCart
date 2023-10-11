using Auth.Api.Mappings;
using Auth.Application.Interfaces;
using Auth.Application.Services;
using Auth.Core.IRepositories;
using Auth.Infrastructure.Data;
using Auth.Infrastructure.Data.Interface;
using Auth.Infrastructure.EFRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

// Database Dependencies
services.AddScoped<IAuthContext, AuthContext>();
services.AddDbContext<AuthContext>(options => options.UseNpgsql(config.GetConnectionString("AuthApiConnection")));


// Service Dependencies
services.AddScoped<IAppUserService, AppUserService>();
services.AddScoped<IAppTokenService, AppTokenService>();

// Repository Dependencies
services.AddScoped<IUserRepository, EFUserRepository>();
services.AddScoped<ITokenRepository, EFTokenRepository>();

// Configuration Mapper Entity <> Dto
services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CreateDtoMappingProfile>();
    cfg.AddProfile<UpdateDtoMappingProfile>();
});

services.AddSingleton(serviceProvider => new MapperConfiguration(cfg =>
{
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
