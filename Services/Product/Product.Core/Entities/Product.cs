using Product.Core.Entities.Base;
using static System.Net.Mime.MediaTypeNames;

namespace Product.Core.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderQuantity { get; set; }

        // Navigation properties
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public required Brand Brand { get; set; }
        public required Category Category { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<ItemImage> Images { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
