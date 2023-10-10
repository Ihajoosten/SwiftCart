using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories.Base;

namespace User.Infrastructure.EFRepositories
{
    public class EFUserRoleRepository : EFRepository<UserRole>, IUserRoleRepository
    {
        public EFUserRoleRepository(IUserContext context) : base(context) { }

        public async Task<IReadOnlyList<Role?>?> GetRolesForUserAsync(int userId)
        {
            var roleIds = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId)
                .ToListAsync();

            return await _context.Roles
                .Where(r => roleIds.Contains(r.Id))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Core.Entities.User?>?> GetUsersInRoleAsync(string roleName)
        {
            var userIds = await _context.UserRoles
                .Where(ur => ur.Role.Name == roleName)
                .Select(ur => ur.UserId)
                .ToListAsync();

            return await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();
        }
    }
}
