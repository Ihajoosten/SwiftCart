using Order.Core.Entities;

namespace Order.Application.Dto.Order
{
    public class UpdateOrderDto
    {
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
