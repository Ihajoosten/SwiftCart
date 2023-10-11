using AutoMapper;
using User.Application.Dto.PhoneNumber;
using User.Application.Interfaces;
using User.Application.Services.Base;
using User.Core.Entities;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class AppPhoneNumberService : ApplicationService<PhoneNumber, PhoneNumberDto, CreatePhoneNumberDto, UpdatePhoneNumberDto>, IAppPhoneNumberService
    {
        private readonly IPhoneNumberRepository _appPhoneNumberRepository;

        public AppPhoneNumberService(IPhoneNumberRepository appPhoneNumberRepository, IMapper mapper)
            : base(appPhoneNumberRepository, mapper)
        {
            _appPhoneNumberRepository = appPhoneNumberRepository ?? throw new ArgumentNullException(nameof(appPhoneNumberRepository));
        }

        public async Task<IEnumerable<PhoneNumberDto?>?> GetByUserIdAsync(int userId)
        {
            var phoneNumbers = await _appPhoneNumberRepository.GetAllAsync();
            return phoneNumbers != null ? _mapper.Map<IEnumerable<PhoneNumberDto>>(phoneNumbers) : null;
        }
    }
}
