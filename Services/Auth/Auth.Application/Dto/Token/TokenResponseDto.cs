
namespace Auth.Application.Dto.Token
{
    public class TokenResponseDto
    {
        public AccessTokenDto AccessToken { get; set; }
        public RefreshTokenDto RefreshToken { get; set; }
    }
}
