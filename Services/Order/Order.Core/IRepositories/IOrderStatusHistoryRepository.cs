using Order.Core.Entities;
using Order.Core.IRepositories.Base;

namespace Order.Core.IRepositories
{
    public interface IOrderStatusHistoryRepository : IRepository<OrderStatusHistory>
    {
        Task<IEnumerable<OrderStatusHistory>> GetStatusHistoryByOrderIdAsync(int orderId);
        Task<OrderStatusHistory> GetLatestStatusByOrderIdAsync(int orderId);
    }
}
