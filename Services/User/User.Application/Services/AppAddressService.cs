using AutoMapper;
using User.Application.Dto.Address;
using User.Application.Interfaces;
using User.Application.Services.Base;
using User.Core.Entities;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class AppAddressService : ApplicationService<Address, AddressDto, CreateAddressDto, UpdateAddressDto>, IAppAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AppAddressService(IAddressRepository addressRepository, IMapper mapper)
            : base(addressRepository, mapper)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public async Task<IEnumerable<AddressDto?>?> GetByUserIdAsync(int userId)
        {
            var addresses = await _addressRepository.GetByUserIdAsync(userId);
            return addresses != null ? _mapper.Map<IEnumerable<AddressDto>>(addresses) : null;
        }
    }
}
