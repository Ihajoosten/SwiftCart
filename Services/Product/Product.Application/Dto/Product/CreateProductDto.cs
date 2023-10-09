using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
