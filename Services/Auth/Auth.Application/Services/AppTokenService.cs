﻿using Auth.Application.Dto.Auth;
using Auth.Application.Dto.Token;
using Auth.Application.Interfaces;
using Auth.Core.Entities;
using Auth.Core.IRepositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Auth.Application.Services
{
    public class AppTokenService : IAppTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly string _jwtSecretKey = "Testing-new-jwt-functionalty";

        public AppTokenService(IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _tokenRepository = tokenRepository ?? throw new ArgumentNullException(nameof(tokenRepository));
        }

        public string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            // For refresh tokens, you may want to store additional information in the token,
            // such as the user's ID or other relevant details.

            var refreshTokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSecretKey);

            var refreshTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMonths(1), // Refresh token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var refreshToken = refreshTokenHandler.CreateToken(refreshTokenDescriptor);
            return refreshTokenHandler.WriteToken(refreshToken);
        }

        public async Task<TokenResponseDto?> GenerateTokensAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);

            // If the user doesn't exist or the password is invalid, return null or handle accordingly
            if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return null;
            }

            // Generate access token and refresh token
            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            // Save the refresh token in the database for future use
            await _tokenRepository.AddAsync(new Token
            {
                UserId = user.Id,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMonths(1) // Set your desired expiration time
            });

            return new TokenResponseDto
            {
                AccessToken = new AccessTokenDto
                {
                    Token = accessToken,
                    ExpiresAt = DateTime.UtcNow.AddHours(1) // Set your desired expiration time
                },
                RefreshToken = new RefreshTokenDto
                {
                    RefreshToken = refreshToken
                }
            };
        }

        public async Task<TokenResponseDto?> RefreshAccessTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            // Retrieve user based on the refresh token
            var token = await _tokenRepository.GetByRefreshTokenAsync(refreshTokenDto.RefreshToken) ?? throw new UnauthorizedAccessException("Invalid refresh token | User Not Found");

            // Retrieve the user based on the UserId in the token
            var user = await _userRepository.GetByEmailAsync(token.Email);

            // Generate a new access token
            var accessToken = GenerateAccessToken(user);

            return new TokenResponseDto
            {
                AccessToken = new AccessTokenDto
                {
                    Token = accessToken,
                    ExpiresAt = DateTime.UtcNow.AddHours(1) // Set your desired expiration time
                },
                RefreshToken = refreshTokenDto // Return the same refresh token
            };
        }

        public async Task RemoveExpiredTokensAsync()
        {
            await _tokenRepository.RemoveExpiredTokensAsync();
        }

        private static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            // Use BCrypt to verify the entered password against the hashed password
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}
