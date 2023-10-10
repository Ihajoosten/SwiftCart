﻿using Order.Core.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Core.IRepositories
{
    public interface IOrderRepository : IRepository<Entities.Order>
    {
        Task<Entities.Order> GetByIdWithDetailsAsync(int orderId);
        Task<IEnumerable<Entities.Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<IEnumerable<Entities.Order>> GetPendingOrdersAsync();
        Task<IEnumerable<Entities.Order>> GetCompletedOrdersAsync();
        Task<IEnumerable<Entities.Order>> GetDeliveredOrdersAsync();
        Task<IEnumerable<Entities.Order>> GetCanceledOrdersAsync();
    }
}
