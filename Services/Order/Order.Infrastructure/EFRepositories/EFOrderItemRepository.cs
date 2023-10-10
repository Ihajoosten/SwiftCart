using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using Order.Core.IRepositories;
using Order.Infrastructure.Data.Interface;
using Order.Infrastructure.EFRepositories.Base;

namespace Order.Infrastructure.EFRepositories
{
    public class EFOrderItemRepository : EFRepository<OrderItem>, IOrderItemRepository
    {
        public EFOrderItemRepository(IOrderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderItem?>?> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.Id == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderItem?>?> GetTopSellingOrderItemsAsync(int count)
        {
            return await _context.OrderItems
                .OrderByDescending(oi => oi.Quantity)
                .Take(count)
                .ToListAsync();
        }
    }
}
