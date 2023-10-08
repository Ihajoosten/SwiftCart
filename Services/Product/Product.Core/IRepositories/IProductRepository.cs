using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface IProductRepository : IRepository<Entities.Product>
    {
        Task<IEnumerable<Entities.Product>> GetProductByName(string name);
        Task<IEnumerable<Entities.Product>> GetProductByBrand(string name)
    }
}
