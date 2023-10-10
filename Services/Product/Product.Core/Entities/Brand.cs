using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class Brand : BaseEntity
    {
        public required string Name { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}
