using Product.Core.Entities;
    
namespace Product.Core.IRepositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ProductBrand>> GetAllBrands();
    }
}
