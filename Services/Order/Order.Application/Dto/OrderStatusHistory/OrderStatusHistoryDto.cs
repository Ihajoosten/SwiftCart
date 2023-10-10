using Order.Core.Entities;

namespace Order.Application.Dto.OrderStatusHistory
{
    public class OrderStatusHistoryDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderStatus OldStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
