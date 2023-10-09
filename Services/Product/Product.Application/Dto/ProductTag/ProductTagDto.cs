using Product.Application.Dto.Product;
using Product.Application.Dto.Tag;

namespace Product.Application.Dto.ProductTag
{
    public class ProductTagDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }

        // Navigation properties
        public ProductDto Product { get; set; }
        public TagDto Tag { get; set; }
    }
}
