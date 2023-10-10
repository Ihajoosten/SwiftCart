﻿using Microsoft.EntityFrameworkCore;
using User.Core.IRepositories;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories.Base;

namespace User.Infrastructure.EFRepositories
{
    public class EFUserRepository : EFRepository<Core.Entities.User>, IUserRepository
    {
        public EFUserRepository(IUserContext dbContext) : base(dbContext) { }

        public async Task<Core.Entities.User?> GetByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        

        public async Task<Core.Entities.User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);


        public async Task<IEnumerable<Core.Entities.User>> GetUsersByRoleAsync(string roleName) =>
            await _context.Users.Where(u => u.UserRoles.Any(ur => ur.Role.Name == roleName)).ToListAsync();
    }
}
