using AutoMapper;
using Order.Application.Dto.OrderItem;
using Order.Application.Interfaces;
using Order.Application.Services.Base;
using Order.Core.Entities;
using Order.Core.IRepositories;

namespace Order.Application.Services
{
    public class AppOrderItemService : ApplicationService<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto>, IAppOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public AppOrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper) : base(orderItemRepository, mapper)
        {
            _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        }

        public async Task<IEnumerable<OrderItemDto?>?> GetOrderItemsByOrderIdAsync(int orderId)
        {
            var orderItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
            return _mapper.Map<IEnumerable<OrderItemDto>?>(orderItems);
        }

        public async Task<IEnumerable<OrderItemDto?>?> GetTopSellingOrderItemsAsync(int count)
        {
            var topSellingOrderItems = await _orderItemRepository.GetTopSellingOrderItemsAsync(count);
            return _mapper.Map<IEnumerable<OrderItemDto>?>(topSellingOrderItems);
        }
    }
}
