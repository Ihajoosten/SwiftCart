using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<IEnumerable<Review?>?> GetReviewsByProductIdAsync(int productId);
        Task<double> GetAverageRatingByProductIdAsync(int productId);
    }
}
