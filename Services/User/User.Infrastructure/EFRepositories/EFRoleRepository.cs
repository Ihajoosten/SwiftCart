using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories.Base;

namespace User.Infrastructure.EFRepositories
{
    public class EFRoleRepository : EFRepository<Role>, IRoleRepository
    {
        public EFRoleRepository(IUserContext dbContext) : base(dbContext) { }
    }
}
