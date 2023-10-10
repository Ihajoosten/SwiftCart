using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using User.Api.Mappings;
using User.Application.Dto.Role;
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

// Auth Dependencies
services.AddScoped<IAuthAppService, AuthAppService>();
services.AddScoped<IPasswordAppService, PasswordAppService>();

// Service Dependencies
services.AddTransient<IApplicationService<UserDto, CreateUserDto, UpdateUserDto>, ApplicationService<User.Core.Entities.User, UserDto, CreateUserDto, UpdateUserDto>>();
services.AddTransient<IApplicationService<RoleDto, CreateRoleDto, UpdateRoleDto>, ApplicationService<Role, RoleDto, CreateRoleDto, UpdateRoleDto>>();

services.AddScoped<IUserAppService, UserAppService>();
services.AddScoped<IRoleAppService, RoleAppService>();
services.AddScoped<IUserRoleAppService, UserRoleAppService>();

// Repository Dependencies
services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
services.AddScoped<IUserRepository, EFUserRepository>();
services.AddScoped<IRoleRepository, EFRoleRepository>();
services.AddScoped<IUserRoleRepository, EFUserRoleRepository>();

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

// Add core services to the container.
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            // Configure JWT validation parameters
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Audience"]
            };
        });

services.AddAuthorization();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();