using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories.Base;

namespace Product.Infrastructure.EFRepositories
{
    public class EFReviewRepository : EFRepository<Review>, IReviewRepository
    {
        public EFReviewRepository(IProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review?>?> GetReviewsByProductIdAsync(int productId)
        {
            var allReviews = await GetAllAsync();
            var filteredReviews = allReviews.Where(p => p?.ProductId == productId).ToList();
            return filteredReviews;
        }

        public async Task<double> GetAverageRatingByProductIdAsync(int productId)
        {
            var allReviews = await GetAllAsync();
            var averageRating = allReviews.Where(r => r?.ProductId == productId).Average(r => r?.Rating)!.Value;
            return averageRating;
        }
    }
}
