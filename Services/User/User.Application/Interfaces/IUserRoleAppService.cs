using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Dto.UserRole;

namespace User.Application.Interfaces
{
    public interface IUserRoleAppService
    {
        Task<UserRoleDto> AddUserToRoleAsync(int userId, int roleId);
        Task<bool> RemoveUserFromRoleAsync(int userId, int roleId);
        Task<IEnumerable<RoleDto>> GetRolesForUserAsync(int userId);
        Task<IEnumerable<UserDto>> GetUsersInRoleAsync(string roleName);
    }
}
