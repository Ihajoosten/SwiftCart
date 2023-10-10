using Order.Core.Entities.Base;

namespace Order.Core.Entities
{
    public class ShippingDetails : BaseEntity
    {
        public required string ShippingAddress { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public required string ContactPerson { get; set; }
        public required string ContactPhone { get; set; }
        public required string ContactEmail { get; set; }
        public required DateTime? ShippedDate { get; set; }
        public required DateTime? DeliveredDate { get; set; }
        
        // Foreign key
        public required int OrderId { get; set; }
        // Navigation properties
        public virtual Order Order { get; set; }
    }
}
