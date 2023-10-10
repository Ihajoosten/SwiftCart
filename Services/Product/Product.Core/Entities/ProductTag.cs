using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class ProductTag : BaseEntity
    {
        public required int ProductId { get; set; }
        public required int TagId { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
