using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }

        // Navigation property
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
