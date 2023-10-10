using AutoMapper;
using User.Application.Dto.Role;
using User.Application.Interfaces;
using User.Application.Services.Base;
using User.Core.Entities;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class RoleAppService : ApplicationService<Role, RoleDto, CreateRoleDto, UpdateRoleDto>, IRoleAppService
    {
        public RoleAppService(IRoleRepository roleRepository, IMapper mapper) : base(roleRepository, mapper) { }
    }
}
