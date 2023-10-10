using Order.Core.Entities.Base;

namespace Order.Core.Entities
{
    public class Order : BaseEntity
    {
        public required int CustomerId { get; set; }
        public required DateTime OrderDate { get; set; }
        public required decimal TotalAmount { get; set; }
        public required OrderStatus OrderStatus { get; set; }
        public required int ShippingDetailsId { get; set; }


        // Navigation properties
        public virtual ShippingDetails ShippingDetails { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<OrderStatusHistory> StatusHistory { get; set; } = new List<OrderStatusHistory>();
    }
}
