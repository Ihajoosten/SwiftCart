using Order.Application.Dto.OrderItem;
using Order.Application.Dto.OrderStatusHistory;
using Order.Application.Dto.ShippingDetails;
using Order.Core.Entities;

namespace Order.Application.Dto.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int ShippingDetailsId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
        public ShippingDetailsDto ShippingDetails { get; set; }
        public List<OrderStatusHistoryDto> StatusHistory { get; set; }
    }
}
