using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Infrastructure.Data.Interface;
using Product.Infrastructure.EFRepositories.Base;

namespace Product.Infrastructure.EFRepositories
{
    public class EFTagRepository : EFRepository<Tag>, ITagRepository
    {
        public EFTagRepository(IProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tag?>?> GetPopularTagsAsync(int count)
        {
            var allTagss = await GetAllAsync();
            var popularTags = allTagss.OrderByDescending(x => x?.ProductTags.Count).Take(count);
            return popularTags;
        }
    }
}
