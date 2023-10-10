using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using Order.Core.IRepositories;
using Order.Infrastructure.Data.Interface;
using Order.Infrastructure.EFRepositories.Base;

namespace Order.Infrastructure.EFRepositories
{
    public class EFOrderRepository : EFRepository<Core.Entities.Order>, IOrderRepository
    {
        public EFOrderRepository(IOrderContext context) : base(context)
        {
        }

        public async Task<Core.Entities.Order?> GetByIdWithDetailsAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.ShippingDetails)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Core.Entities.Order?>?> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Order?>?> GetPendingOrdersAsync()
        {
            return await _context.Orders
                .Where(o => o.OrderStatus == OrderStatus.Pending)
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Order?>?> GetCompletedOrdersAsync()
        {
            return await _context.Orders
                .Where(o => o.OrderStatus == OrderStatus.Completed)
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Order?>?> GetDeliveredOrdersAsync()
        {
            return await _context.Orders
                .Where(o => o.OrderStatus == OrderStatus.Delivered)
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Order?>?> GetCanceledOrdersAsync()
        {
            return await _context.Orders
                .Where(o => o.OrderStatus == OrderStatus.Canceled)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderStatusHistory>> GetOrderStatusHistoryAsync(int orderId)
        {
            return await _context.OrderStatusHistories
                .Where(history => history.OrderId == orderId)
                .ToListAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.OrderStatus = newStatus;
                await _context.SaveChangesAsync();
            }
        }
    }
}
