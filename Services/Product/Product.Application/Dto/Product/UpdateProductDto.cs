
namespace Product.Application.Dto.Product
{
    public class UpdateProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
