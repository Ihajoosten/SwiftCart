using Auth.Application.Dto.Auth;
using Auth.Core.Entities;

namespace Auth.Application.Interfaces
{
    public interface IAppUserService
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> ValidateUserCredentialsAsync(LoginDto loginDto);
        Task<bool> RegisterUserAsync(RegisterDto registerDto);
        Task<bool> UpdateCredentialsAsync(UpdateCredentialsDto updateCredentialsDto);
        Task<bool> DeleteUserAsync(string email);
    }
}
