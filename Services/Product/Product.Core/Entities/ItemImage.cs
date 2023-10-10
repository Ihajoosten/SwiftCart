
using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class ItemImage : BaseEntity
    {
        public required string Url { get; set; }

        // Foreign key
        public required int ProductId { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}
