using Product.Core.Entities;
using Product.Core.IRepositories.Base;

namespace Product.Core.IRepositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<IEnumerable<Tag>> GetPopularTagsAsync(int count);
    }
}
