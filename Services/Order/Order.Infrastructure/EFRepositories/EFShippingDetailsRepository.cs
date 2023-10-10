using Microsoft.EntityFrameworkCore;
using Order.Core.Entities;
using Order.Core.IRepositories;
using Order.Infrastructure.Data.Interface;
using Order.Infrastructure.EFRepositories.Base;

namespace Order.Infrastructure.EFRepositories
{
    public class EFShippingDetailsRepository : EFRepository<ShippingDetails>, IShippingDetailsRepository
    {
        public EFShippingDetailsRepository(IOrderContext context) : base(context)
        {
        }

        public async Task<ShippingDetails?> GetShippingDetailsByOrderIdAsync(int orderId)
        {
            return await _context.ShippingDetails
                .FirstOrDefaultAsync(sd => sd.OrderId == orderId);
        }
    }
}
