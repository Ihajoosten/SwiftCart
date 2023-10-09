
namespace Product.Application.Dto.Review
{
    public class UpdateReviewDto
    {
        public int Rating { get; set; }  
        public string Comment { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
