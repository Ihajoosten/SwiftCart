using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Interfaces.Base;

namespace User.Application.Interfaces
{
    public interface IUserAppService : IApplicationService<UserDto, CreateUserDto, UpdateUserDto>
    {
        Task<UserDto?> GetUserByUsernameAsync(string username);
        Task<UserDto?> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserDto>> GetUsersInRoleAsync(string roleName);
        Task<IEnumerable<RoleDto>> GetRolesForUserAsync(int userId);
    }
}
