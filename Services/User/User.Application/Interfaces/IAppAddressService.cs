using User.Application.Dto.Address;
using User.Application.Interfaces.Base;

namespace User.Application.Interfaces
{
    public interface IAppAddressService : IApplicationService<AddressDto, CreateAddressDto, UpdateAddressDto>
    {
        Task<IEnumerable<AddressDto?>?> GetByUserIdAsync(int userId);
    }
}
