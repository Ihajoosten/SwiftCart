using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories.Base;

namespace User.Infrastructure.EFRepositories
{
    public class EFUserRepository : EFRepository<Core.Entities.User>, IUserRepository
    {
        public EFUserRepository(IUserContext context) : base(context) { }

        public async Task<Core.Entities.User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Core.Entities.User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserRoleAsync(int userId, UserRole role)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.Role = role;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserRoleAsync(int userId, UserRole role)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.Role = role;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveUserRoleAsync(int userId, UserRole role)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                user.Role = null;
                await _context.SaveChangesAsync();
            }
        }
    }
}
