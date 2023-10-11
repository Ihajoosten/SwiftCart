
namespace Auth.Application.Dto.Token
{
    public class AccessTokenDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
