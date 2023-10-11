using User.Core.Entities;
using User.Core.IRepositories.Base;

namespace User.Core.IRepositories
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumber>
    {
        Task<IEnumerable<PhoneNumber?>?> GetByUserIdAsync(int userId);
    }
}
