using Auth.Core.Entities;
using Auth.Core.IRepositories.Base;

namespace Auth.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
    }
}
