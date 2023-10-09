using Product.Application.Dto.Review;
using Product.Application.Interfaces.Base;

namespace Product.Application.Interfaces
{
    public interface IAppReviewService : IApplicationService<ReviewDto, CreateReviewDto, UpdateReviewDto>
    {
        Task<IEnumerable<ReviewDto?>?> GetReviewsByProductIdAsync(int productId);
        Task<double> GetAverageRatingByProductIdAsync(int productId);
    }
}
