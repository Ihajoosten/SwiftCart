using Auth.Core.Entities;
using Auth.Core.IRepositories.Base;

namespace Auth.Core.IRepositories
{
    public interface ITokenRepository : IRepository<Token>
    {
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
        Task<IEnumerable<Token?>?> GetTokensByUserIdAsync(int userId);
        Task RemoveExpiredTokensAsync();
    }
}
