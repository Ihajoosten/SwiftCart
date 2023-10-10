using AutoMapper;
using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Dto.UserRole;
using User.Core.Entities;

namespace User.Api.Mappings
{
    public class CreateDtoMappingProfile : Profile
    {
        public CreateDtoMappingProfile()
        {
            CreateMap<CreateUserDto, Core.Entities.User>();
            CreateMap<CreateRoleDto, Role>();
            CreateMap<CreateUserRoleDto, UserRole>();
        }
    }
}