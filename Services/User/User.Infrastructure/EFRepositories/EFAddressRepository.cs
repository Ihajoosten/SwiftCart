using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories.Base;

namespace User.Infrastructure.EFRepositories
{
    public class EFAddressRepository : EFRepository<Address>, IAddressRepository
    {
        public EFAddressRepository(IUserContext context) : base(context) { }

        public async Task<IEnumerable<Address?>?> GetByUserIdAsync(int userId)
        {
            return await _context.Addresses.Where(t => t.UserId == userId).ToListAsync();
        }
    }
}
