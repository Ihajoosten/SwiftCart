using Order.Core.Entities.Base;

namespace Order.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public required int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
