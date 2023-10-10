﻿using User.Core.Entities;
using User.Core.IRepositories.Base;

namespace User.Core.IRepositories
{
    public interface IUserRepository : IRepository<Entities.User>
    {
        Task<Entities.User?> GetByUsernameAsync(string username);
        Task<Entities.User?> GetByEmailAsync(string email);
        Task<IEnumerable<Entities.User>> GetByRoleAsync(string roleName);
        Task<IEnumerable<Role>> GetRolesForUserAsync(int userId);
    }
}