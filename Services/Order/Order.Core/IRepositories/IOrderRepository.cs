using Order.Core.Entities;
using Order.Core.IRepositories.Base;

namespace Order.Core.IRepositories
{
    public interface IOrderRepository : IRepository<Entities.Order>
    {
        Task<Entities.Order?> GetByIdWithDetailsAsync(int orderId);
        Task<IEnumerable<Entities.Order?>?> GetOrdersByCustomerIdAsync(int customerId);
        Task<IEnumerable<Entities.Order?>?> GetPendingOrdersAsync();
        Task<IEnumerable<Entities.Order?>?> GetCompletedOrdersAsync();
        Task<IEnumerable<Entities.Order?>?> GetDeliveredOrdersAsync();
        Task<IEnumerable<Entities.Order?>?> GetCanceledOrdersAsync();
        Task<IEnumerable<OrderStatusHistory>> GetOrderStatusHistoryAsync(int orderId);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
    }
}
