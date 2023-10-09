using Product.Application.Dto.Brand;
using Product.Application.Dto.Category;

namespace Product.Application.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public BrandDto Brand { get; set; }
        public CategoryDto Category { get; set; }
    }
}
