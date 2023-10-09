using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
