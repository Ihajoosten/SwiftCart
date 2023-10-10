using Order.Core.Entities.Base;

namespace Order.Core.Entities
{
    public class OrderStatusHistory : BaseEntity
    {
        public required int OrderId { get; set; }
        public required OrderStatus OldStatus { get; set; }
        public required OrderStatus NewStatus { get; set; }
        public required DateTime DateChanged { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Delivered,
        Canceled,
        Completed
    }
}
