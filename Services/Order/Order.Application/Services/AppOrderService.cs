using AutoMapper;
using Order.Application.Dto.Order;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Interfaces;
using Order.Application.Services.Base;
using Order.Core.Entities;
using Order.Core.IRepositories;

namespace Order.Application.Services
{
    public class AppOrderService : ApplicationService<Core.Entities.Order, OrderDto, CreateOrderDto, UpdateOrderDto>, IAppOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusHistoryRepository _orderStatusHistoryRepository;

        public AppOrderService(IOrderRepository orderRepository, IOrderStatusHistoryRepository orderStatusHistoryRepository, IMapper mapper)
            : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _orderStatusHistoryRepository = orderStatusHistoryRepository ?? throw new ArgumentNullException(nameof(orderStatusHistoryRepository));
        }

        public async Task<IEnumerable<OrderDto?>?> GetOrdersByCustomerAsync(int customerId) => _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetOrdersByCustomerIdAsync(customerId));
        public async Task<IEnumerable<OrderStatusHistoryDto>> GetOrderStatusHistoryAsync(int orderId) => _mapper.Map<IEnumerable<OrderStatusHistoryDto>>(await _orderRepository.GetOrderStatusHistoryAsync(orderId));
        public async Task<IEnumerable<OrderDto?>?> GetCanceledOrdersAsync() => _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetCanceledOrdersAsync());
        public async Task<IEnumerable<OrderDto?>?> GetCompletedOrdersAsync() => _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetCompletedOrdersAsync());
        public async Task<IEnumerable<OrderDto?>?> GetDeliveredOrdersAsync() => _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetDeliveredOrdersAsync());
        public async Task<IEnumerable<OrderDto?>?> GetPendingOrdersAsync() => _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetPendingOrdersAsync());
        public async Task<OrderDto> GetOrderWithDetailsAsync(int orderId) => _mapper.Map<OrderDto>(await _orderRepository.GetByIdWithDetailsAsync(orderId));

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null) return;

            var oldStatus = order.OrderStatus;
            order.OrderStatus = newStatus;

            await _orderRepository.UpdateAsync(order);

            var statusHistory = new OrderStatusHistoryDto
            {
                OrderId = orderId,
                OldStatus = oldStatus,
                NewStatus = newStatus,
                DateChanged = DateTime.Now
            };
            var entity = _mapper.Map<OrderStatusHistory>(statusHistory);
            await _orderStatusHistoryRepository.AddAsync(entity);
        }
    }
}
