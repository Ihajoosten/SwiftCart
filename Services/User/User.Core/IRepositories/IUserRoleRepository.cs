using User.Core.Entities;
using User.Core.IRepositories.Base;

namespace User.Core.IRepositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        Task<IReadOnlyList<Role?>?> GetRolesForUserAsync(int userId);
        Task<IReadOnlyList<Entities.User?>?> GetUsersInRoleAsync(string roleName);
    }
}
