using Order.Core.Entities;
using Order.Core.IRepositories.Base;
namespace Order.Core.IRepositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderItem>> GetTopSellingProductsAsync(int count);
    }
}
