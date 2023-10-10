using Order.Application.Dto.Order;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Interfaces.Base;
using Order.Core.Entities;

namespace Order.Application.Interfaces
{
    public interface IAppOrderService : IApplicationService<OrderDto, CreateOrderDto, UpdateOrderDto>
    {
        Task<OrderDto> GetOrderWithDetailsAsync(int orderId);
        Task<IEnumerable<OrderDto?>?> GetOrdersByCustomerAsync(int customerId);
        Task<IEnumerable<OrderDto?>?> GetPendingOrdersAsync();
        Task<IEnumerable<OrderDto?>?> GetCompletedOrdersAsync();
        Task<IEnumerable<OrderDto?>?> GetDeliveredOrdersAsync();
        Task<IEnumerable<OrderDto?>?> GetCanceledOrdersAsync();
        Task<IEnumerable<OrderStatusHistoryDto>> GetOrderStatusHistoryAsync(int orderId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
    }
}