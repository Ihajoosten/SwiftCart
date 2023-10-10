using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Interfaces.Base;

namespace Order.Application.Interfaces
{
    public interface IAppOrderStatusHistoryService : IApplicationService<OrderStatusHistoryDto, CreateOrderStatusHistoryDto, UpdateOrderStatusHistoryDto>
    {
        Task<IEnumerable<OrderStatusHistoryDto?>?> GetStatusHistoryByOrderIdAsync(int orderId);
        Task<OrderStatusHistoryDto?> GetLatestStatusByOrderIdAsync(int orderId);
    }
}
