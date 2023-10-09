using System.ComponentModel.DataAnnotations;


namespace Product.Application.Dto.ItemImage
{
    public class CreateItemImageDto
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public int ProductId { get; set; }

    }
}
