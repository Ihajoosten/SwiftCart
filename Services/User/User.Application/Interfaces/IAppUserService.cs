using User.Application.Dto.User;
using User.Application.Interfaces.Base;

namespace User.Application.Interfaces
{
    public interface IAppUserService : IApplicationService<UserDto, CreateUserDto, UpdateUserDto>
    {
        Task<UserDto?> GetByUsernameAsync(string username);
        Task<UserDto?> GetByEmailAsync(string email);
        Task AddUserRoleAsync(UserRoleDto userRoleDto);
        Task UpdateUserRoleAsync(UserRoleDto userRoleDto);
        Task RemoveUserRoleAsync(UserRoleDto userRoleDto);
    }
}
