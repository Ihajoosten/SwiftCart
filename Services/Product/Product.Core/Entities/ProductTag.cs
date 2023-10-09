using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class ProductTag : BaseEntity
    {
        public required int ProductId { get; set; }
        public required int TagId { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public Tag Tag { get; set; }
    }
}
