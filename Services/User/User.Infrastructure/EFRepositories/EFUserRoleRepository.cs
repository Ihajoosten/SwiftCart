using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Infrastructure.Data;

namespace User.Infrastructure.EFRepositories
{
    public class EFUserRoleRepository : IUserRoleRepository
    {
        private readonly UserContext _context;

        public EFUserRoleRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<object> AddUserToRoleAsync(int userId, int roleId)
        {
            var userRole = new UserRole { UserId = userId, RoleId = roleId };
            var created = await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return created;
        }

        public async Task<bool> RemoveUserFromRoleAsync(int userId, int roleId)
        {
            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }

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
