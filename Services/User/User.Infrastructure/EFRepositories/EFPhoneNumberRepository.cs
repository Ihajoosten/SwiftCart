using Microsoft.EntityFrameworkCore;
using User.Core.Entities;
using User.Core.IRepositories;
using User.Infrastructure.Data.Interface;
using User.Infrastructure.EFRepositories.Base;

namespace User.Infrastructure.EFRepositories
{
    public class EFPhoneNumberRepository : EFRepository<PhoneNumber>, IPhoneNumberRepository
    {
        public EFPhoneNumberRepository(IUserContext userContext) : base(userContext) { }

        public async Task<IEnumerable<PhoneNumber?>?> GetByUserIdAsync(int userId)
        {
            return await _context.PhoneNumbers.Where(t => t.UserId == userId).ToListAsync();
        }
    }
}
