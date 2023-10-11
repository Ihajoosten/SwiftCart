using Auth.Core.Entities;
using Auth.Core.IRepositories;
using Auth.Infrastructure.Data.Interface;
using Auth.Infrastructure.EFRepositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.EFRepositories
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        public EFUserRepository(IAuthContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
