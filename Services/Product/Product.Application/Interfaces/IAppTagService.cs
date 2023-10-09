using Product.Application.Dto.Tag;
using Product.Application.Interfaces.Base;

namespace Product.Application.Interfaces
{
    public interface IAppTagService : IApplicationService<TagDto, CreateTagDto, UpdateTagDto>
    {
        Task<IEnumerable<TagDto?>?> GetPopularTagsAsync(int count);
    }
}
