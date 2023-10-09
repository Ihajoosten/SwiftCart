using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IProductRepository : IRepository<Entities.Product>
    {
        Task<IEnumerable<Entities.Product?>?> GetProductsByBrandAsync(int brandId);
        Task<IEnumerable<Entities.Product?>?> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Entities.Product?>?> GetProductsByTagAsync(int tagId);
        Task<IEnumerable<Entities.Product?>?> GetProductsByRatingAsync(int minRating);
        Task<IEnumerable<Entities.Product?>?> GetTopSellingProductsAsync(int count);
        Task<IEnumerable<Entities.Product?>?> GetNewArrivalProductsAsync(int count);
    }
}
