using User.Core.Entities;
using User.Core.IRepositories.Base;

namespace User.Core.IRepositories
{
    public interface IUserRoleRepository
    {
        Task AddUserToRoleAsync(Core.Entities.User user, Role role);
        Task RemoveUserFromRoleAsync(Core.Entities.User user, Role role);
        Task<IReadOnlyList<Role?>?> GetRolesForUserAsync(int userId);
        Task<IReadOnlyList<Entities.User?>?> GetUsersInRoleAsync(string roleName);
    }
}
