using Order.Application.Dto.ShippingDetails;
using Order.Application.Interfaces.Base;

namespace Order.Application.Interfaces
{
    public interface IAppShippingDetailsService : IApplicationService<ShippingDetailsDto, CreateShippingDetailsDto, UpdateShippingDetailsDto>
    {
        Task<ShippingDetailsDto?> GetShippingDetailsByOrderIdAsync(int orderId);
    }
}
