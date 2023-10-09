using Microsoft.EntityFrameworkCore;
using Product.Core.IRepositories;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories.Base;

namespace Product.Infrastructure.EFRepositories
{
    public class EFProductRepository : EFRepository<Core.Entities.Product>, IProductRepository
    {
        public EFProductRepository(IProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Core.Entities.Product?>?> GetProductsByBrandAsync(int brandId)
        {
            var allProducts = await GetAllAsync();
            var filteredProducts = allProducts.Where(p => p?.BrandId == brandId).ToList();
            return filteredProducts;
        }

        public async Task<IEnumerable<Core.Entities.Product?>?> GetProductsByCategoryAsync(int categoryId)
        {
            var allProducts = await GetAllAsync();
            var filteredProducts = allProducts.Where(p => p?.CategoryId == categoryId).ToList();
            return filteredProducts;
        }

        public async Task<IEnumerable<Core.Entities.Product?>?> GetProductsByTagAsync(int tagId)
        {
            return await _context.ProductTags
                .Where(pt => pt.TagId == tagId)
                .Select(pt => pt.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Product?>?> GetProductsByRatingAsync(int minRating)
        {
            var allProducts = await GetAllAsync();
            var filteredProducts = allProducts.Where(p => p?.Reviews.Average(r => r.Rating) >= minRating).ToList();
            return filteredProducts;
        }

        public async Task<IEnumerable<Core.Entities.Product?>?> GetTopSellingProductsAsync(int count)
        {
            var allProducts = await GetAllAsync();
            var filteredProducts = allProducts.OrderByDescending(x => x?.OrderQuantity).Take(count);
            return filteredProducts;
        }

        public async Task<IEnumerable<Core.Entities.Product?>?> GetNewArrivalProductsAsync(int count)
        {
            var allProducts = await GetAllAsync();
            var filteredProducts = allProducts.OrderByDescending(x => x?.CreatedAt).Take(count);
            return filteredProducts;
        }
    }
}
