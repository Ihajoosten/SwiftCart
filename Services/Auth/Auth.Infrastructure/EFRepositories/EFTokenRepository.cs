using Auth.Core.Entities;
using Auth.Core.IRepositories;
using Auth.Infrastructure.Data.Interface;
using Auth.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.EFRepositories
{
    public class EFTokenRepository : EFRepository<Token>, ITokenRepository
    {
        public EFTokenRepository(IAuthContext context) : base(context) { }

        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            var token = await _context.Tokens.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (token == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Tokens.Contains(token));
            return user;
        }

        public async Task<IEnumerable<Token?>?> GetTokensByUserIdAsync(int userId)
        {
            return await _context.Tokens.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task RemoveExpiredTokensAsync()
        {
            var expiredTokens = await _context.Tokens
                        .Where(t => t.ExpiresAt < DateTime.UtcNow)
                        .ToListAsync();

            if (expiredTokens.Any())
            {
                _context.Tokens.RemoveRange(expiredTokens);
                await _context.SaveChangesAsync();
            }
        }
    }
}
