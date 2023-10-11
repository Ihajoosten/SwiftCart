using User.Core.Entities;
using User.Core.IRepositories.Base;

namespace User.Core.IRepositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<IEnumerable<Address?>?> GetByUserIdAsync(int userId);
    }
}
