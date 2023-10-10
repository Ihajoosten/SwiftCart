using User.Application.Dto.Role;
using User.Application.Interfaces.Base;

namespace User.Application.Interfaces
{
    public interface IRoleAppService : IApplicationService<RoleDto, CreateRoleDto, UpdateRoleDto>
    {
        Task<RoleDto?> GetRoleByNameAsync(string roleName);
    }
}
