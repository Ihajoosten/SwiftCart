using Order.Core.Entities;
using Order.Core.IRepositories.Base;

namespace Order.Core.IRepositories
{
    public interface IShippingDetailsRepository : IRepository<ShippingDetails>
    {
        Task<ShippingDetails?> GetShippingDetailsByOrderIdAsync(int orderId);
    }
}
