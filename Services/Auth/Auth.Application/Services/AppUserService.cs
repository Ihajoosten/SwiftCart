using Auth.Application.Dto.Auth;
using Auth.Application.Interfaces;
using Auth.Core.Entities;
using Auth.Core.IRepositories;

namespace Auth.Application.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IUserRepository _userRepository;

        public AppUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> ValidateUserCredentialsAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);

            // If the user doesn't exist or the password is invalid, return false
            return user != null && VerifyPassword(enteredPassword: loginDto.Password, hashedPassword: user.PasswordHash);
        }

        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            // Hash the password before storing it
            var hashedPassword = HashPassword(registerDto.Password);

            var newUser = new User
            {
                Email = registerDto.Email,
                Username = registerDto.Username,
                PasswordHash = hashedPassword,
                CreatedAt = registerDto.CreatedAt
            };

            var created = await _userRepository.AddAsync(newUser);
            return created != null ? true : false;
        }

        private static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            // Use BCrypt to verify the entered password against the hashed password
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

        private static string HashPassword(string password)
        {
            // Use BCrypt to hash the password
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<bool> UpdateCredentialsAsync(UpdateCredentialsDto updateCredentialsDto)
        {
            var updatedUser = new User
            {
                Id = updateCredentialsDto.Id,
                Email = updateCredentialsDto.NewEmail,
                Username = updateCredentialsDto.NewUsername,
                PasswordHash = HashPassword(updateCredentialsDto.NewPassword),
                Role = updateCredentialsDto.NewRole,
                UpdatedAt = updateCredentialsDto.UpdatedAt
            };
            return await _userRepository.UpdateAsync(updatedUser);
        }

        public async Task<bool> DeleteUserAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            return user != null && await _userRepository.DeleteAsync(user);
        }
    }
}
