using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories.Base;

namespace User.Infrastructure.EFRepositories
{
    public class EFUserRepository : EFRepository<Core.Entities.User>, IUserRepository
    {
        public EFUserRepository(IUserContext dbContext) : base(dbContext) { }

        public async Task<Core.Entities.User?> GetByUsernameAsync(string username)
        {
           return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }


        public async Task<Core.Entities.User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
