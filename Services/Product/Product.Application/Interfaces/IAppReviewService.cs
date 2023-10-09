using Product.Application.Dto.Review;

namespace Product.Application.Interfaces
{
    public interface IAppReviewService
    {
        Task<IEnumerable<ReviewDto?>?> GetReviewsByProductIdAsync(int productId);
        Task<double> GetAverageRatingByProductIdAsync(int productId);
    }
}
