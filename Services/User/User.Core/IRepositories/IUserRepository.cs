using User.Core.Entities;
using User.Core.IRepositories.Base;

namespace User.Core.IRepositories
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        Task<Entities.User?> GetByUsernameAsync(string username);
        Task<Entities.User?> GetByEmailAsync(string email);
        Task AddUserRoleAsync(int userId, UserRole role);
        Task UpdateUserRoleAsync(int userId, UserRole role);
        Task RemoveUserRoleAsync(int userId, UserRole role);
    }
}
