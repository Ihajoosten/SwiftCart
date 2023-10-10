using AutoMapper;
using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Dto.UserRole;
using User.Core.Entities;

namespace User.Api.Mappings
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Core.Entities.User, UserDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<UserRoleDto, UserRoleDto>();
        }
    }
}