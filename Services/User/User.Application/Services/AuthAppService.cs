using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Application.Interfaces;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IPasswordAppService _passwordService;

        public AuthAppService(IUserRepository userRepository, IConfiguration configuration, IPasswordAppService passwordService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _passwordService = passwordService;
        }

        public async Task<string?> AuthenticateUserAsync(string username, string password)
        {
            // Verify user credentials
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !_passwordService.VerifyPassword(user.PasswordHash, password))
            {
                return null;
            }

            // Generate and return a JWT token
            var generator = new JwtTokenGenerator(_configuration);
            var token = generator.GenerateToken(user);
            return token;
        }
    }

    internal class JwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Core.Entities.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
