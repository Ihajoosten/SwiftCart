using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
