using AutoMapper;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Interfaces;
using Order.Application.Services.Base;
using Order.Core.Entities;
using Order.Core.IRepositories;

namespace Order.Application.Services
{
    public class AppOrderStatusHistoryService : ApplicationService<OrderStatusHistory, OrderStatusHistoryDto, CreateOrderStatusHistoryDto, UpdateOrderStatusHistoryDto>, IAppOrderStatusHistoryService
    {
        private readonly IOrderStatusHistoryRepository _orderStatusHistoryRepository;

        public AppOrderStatusHistoryService(IOrderStatusHistoryRepository orderStatusHistoryRepository, IMapper mapper) : base(orderStatusHistoryRepository, mapper)
        {
            _orderStatusHistoryRepository = orderStatusHistoryRepository ?? throw new ArgumentNullException(nameof(orderStatusHistoryRepository));
        }

        public async Task<OrderStatusHistoryDto?> GetLatestStatusByOrderIdAsync(int orderId)
        {
            var latestStatus = await _orderStatusHistoryRepository.GetLatestStatusByOrderIdAsync(orderId);
            return _mapper.Map<OrderStatusHistoryDto?>(latestStatus);
        }

        public async Task<IEnumerable<OrderStatusHistoryDto?>?> GetStatusHistoryByOrderIdAsync(int orderId)
        {
            var history = await _orderStatusHistoryRepository.GetStatusHistoryByOrderIdAsync(orderId);
            return _mapper.Map<IEnumerable<OrderStatusHistoryDto>?>(history);
        }
    }
}
