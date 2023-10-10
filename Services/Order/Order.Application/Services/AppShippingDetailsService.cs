using AutoMapper;
using Order.Application.Dto.ShippingDetails;
using Order.Application.Interfaces;
using Order.Application.Services.Base;
using Order.Core.Entities;
using Order.Core.IRepositories;

namespace Order.Application.Services
{
    public class AppShippingDetailsService : ApplicationService<ShippingDetails, ShippingDetailsDto, CreateShippingDetailsDto, UpdateShippingDetailsDto>, IAppShippingDetailsService
    {
        private readonly IShippingDetailsRepository _shippingDetailsRepository;

        public AppShippingDetailsService(IShippingDetailsRepository shippingDetailsRepository, IMapper mapper) : base(shippingDetailsRepository, mapper)
        {
            _shippingDetailsRepository = shippingDetailsRepository ?? throw new ArgumentNullException(nameof(shippingDetailsRepository));
        }

        public async Task<ShippingDetailsDto?> GetShippingDetailsByOrderIdAsync(int orderId)
        {
            var latestStatus = await _shippingDetailsRepository.GetShippingDetailsByOrderIdAsync(orderId);
            return _mapper.Map<ShippingDetailsDto?>(latestStatus);
        }
    }
}