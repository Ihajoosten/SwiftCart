using User.Application.Dto.PhoneNumber;
using User.Application.Interfaces.Base;

namespace User.Application.Interfaces
{
    public interface IAppPhoneNumberService : IApplicationService<PhoneNumberDto, CreatePhoneNumberDto, UpdatePhoneNumberDto>
    {
        Task<IEnumerable<PhoneNumberDto?>?> GetByUserIdAsync(int userId);
    }
}
