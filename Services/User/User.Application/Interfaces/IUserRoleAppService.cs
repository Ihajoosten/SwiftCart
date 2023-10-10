using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Dto.UserRole;
using User.Application.Interfaces.Base;

namespace User.Application.Interfaces
{
    public interface IUserRoleAppService : IApplicationService<UserRoleDto, CreateUserRoleDto, UpdateUserRoleDto>
    {
        Task<IEnumerable<RoleDto>> GetRolesForUserAsync(int userId);
        Task<IEnumerable<UserDto>> GetUsersInRoleAsync(string roleName);
    }
}
