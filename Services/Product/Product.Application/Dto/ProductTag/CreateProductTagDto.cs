using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.ProductTag
{
    public class CreateProductTagDto
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        public int TagId { get; set; }
    }
}
