using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.Tag
{
    public class CreateTagDto
    {
        [Required]
        public string Name { get; set; }
    }
}
