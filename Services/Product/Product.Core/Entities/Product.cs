using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public virtual required Brand Brand { get; set; }
        public virtual required Category Category { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ItemImage> Images { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
