using Auth.Application.Dto.Auth;
using Auth.Application.Dto.Token;

namespace Auth.Application.Interfaces
{
    public interface IAppTokenService
    {
        Task<TokenResponseDto?> GenerateTokensAsync(LoginDto loginDto);
        Task<TokenResponseDto?> RefreshAccessTokenAsync(RefreshTokenDto refreshTokenDto);
        Task RemoveExpiredTokensAsync();
    }
}
