using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public bool IsMainCategory { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}
