using AutoMapper;
using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Dto.UserRole;
using User.Core.Entities;

namespace User.Api.Mappings
{
    public class UpdateDtoMappingProfile : Profile
    {
        public UpdateDtoMappingProfile()
        {
            CreateMap<UpdateUserDto, Core.Entities.User>();
            CreateMap<UpdateRoleDto, Role>();
            CreateMap<UpdateUserRoleDto, UserRole>();
        }
    }
}
