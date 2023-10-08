using Product.Core.Entities;

namespace Product.Core.IRepositories
{
    public interface ITypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}
