using System.ComponentModel.DataAnnotations;

namespace Product.Application.Dto.Review
{
    public class CreateReviewDto
    {
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
        [Required]
        public int ProductId { get; set; }
    }
}
