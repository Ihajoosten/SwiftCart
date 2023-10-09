using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.Brand
{
    public class CreateBrandDto
    {
        [Required]
        public string Name { get; set; }
    }
}
