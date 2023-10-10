using User.Core.Entities;

namespace User.Core.IRepositories
{
    public interface IUserRoleRepository
    {
        Task<object> AddUserToRoleAsync(int userId, int roleId);
        Task<bool> RemoveUserFromRoleAsync(int userId, int roleId);
        Task<IReadOnlyList<Role?>?> GetRolesForUserAsync(int userId);
        Task<IReadOnlyList<Entities.User?>?> GetUsersInRoleAsync(string roleName);
    }
}
