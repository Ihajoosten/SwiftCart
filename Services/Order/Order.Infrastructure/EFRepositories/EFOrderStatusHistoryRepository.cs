using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using Order.Core.IRepositories;
using Order.Infrastructure.Data.Interface;
using Order.Infrastructure.EFRepositories.Base;

namespace Order.Infrastructure.EFRepositories
{
    public class EFOrderStatusHistoryRepository : EFRepository<OrderStatusHistory>, IOrderStatusHistoryRepository
    {
        public EFOrderStatusHistoryRepository(IOrderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderStatusHistory?>?> GetStatusHistoryByOrderIdAsync(int orderId)
        {
            return await _context.OrderStatusHistories
                .Where(osh => osh.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<OrderStatusHistory?> GetLatestStatusByOrderIdAsync(int orderId)
        {
            return await _context.OrderStatusHistories
                .Where(osh => osh.OrderId == orderId)
                .OrderByDescending(osh => osh.CreatedAt)
                .FirstOrDefaultAsync();
        }
    }
}
