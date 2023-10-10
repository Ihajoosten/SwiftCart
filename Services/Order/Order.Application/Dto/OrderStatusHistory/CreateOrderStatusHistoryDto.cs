using Order.Core.Entities;

namespace Order.Application.Dto.OrderStatusHistory
{
    public class CreateOrderStatusHistoryDto
    {
        public int OrderId { get; set; }
        public OrderStatus OldStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
