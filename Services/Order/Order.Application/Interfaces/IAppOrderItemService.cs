using Order.Application.Dto.OrderItem;
using Order.Application.Interfaces.Base;

namespace Order.Application.Interfaces
{
    public interface IAppOrderItemService : IApplicationService<OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>
    {
        Task<IEnumerable<OrderItemDto?>?> GetOrderItemsByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderItemDto?>?> GetTopSellingOrderItemsAsync(int count);
    }
}