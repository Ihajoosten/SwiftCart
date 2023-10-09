using Product.Application.Dto.Tag;

namespace Product.Application.Interfaces
{
    public interface IAppTagService
    {
        Task<IEnumerable<TagDto?>?> GetPopularTagsAsync(int count);
    }
}
