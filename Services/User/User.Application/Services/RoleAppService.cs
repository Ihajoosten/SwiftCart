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
        private readonly IRoleRepository _roleRepository;

        public RoleAppService(IRoleRepository roleRepository, IMapper mapper) : base(roleRepository, mapper)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<RoleDto?> GetRoleByNameAsync(string roleName)
        {
            var role = await _roleRepository.GetByNameAsync(roleName);
            return _mapper.Map<RoleDto>(role);
        }
    }
}
