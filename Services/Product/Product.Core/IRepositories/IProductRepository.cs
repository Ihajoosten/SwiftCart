using Product.Core.Specs;

namespace Product.Core.IRepositories
{
    public interface IProductRepository
    {
        Task<Pagination<Entities.Product>> GetProducts(CatalogSpecParams catalogSpecParams);
        Task<Entities.Product> GetProduct(string id);
        Task<IEnumerable<Entities.Product>> GetProductByName(string name);
        Task<IEnumerable<Entities.Product>> GetProductByBrand(string name);
        Task<Entities.Product> CreateProduct(Entities.Product product);
        Task<bool> UpdateProduct(Entities.Product product);
        Task<bool> DeleteProduct(string id);
    }
}
