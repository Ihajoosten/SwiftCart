using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.Brand
{
    public class UpdateBrandDto
    {
        [Required]
        public string Name { get; set; }
    }
}
