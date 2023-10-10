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
        public async Task AddUserToRoleAsync(Core.Entities.User user, Role role)
        {
            var userRole = new UserRole { UserId = user.Id, RoleId = role.Id };
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserFromRoleAsync(Core.Entities.User user, Role role)
        {
            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == user.Id && ur.RoleId == role.Id);

            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
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
