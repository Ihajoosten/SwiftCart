using AutoMapper;
using Product.Application.Dto.Tag;
using Product.Application.Interfaces;
using Product.Application.Services.Base;
using Product.Core.Entities;
using Product.Core.IRepositories;

namespace Product.Application.Services
{
    public class AppTagService : ApplicationService<Tag, TagDto, CreateTagDto, UpdateTagDto>, IAppTagService
    {
        private readonly ITagRepository _tagRepository;

        public AppTagService(ITagRepository tagRepository, IMapper mapper)
            : base(tagRepository, mapper)
        {
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

        public async Task<IEnumerable<TagDto?>?> GetPopularTagsAsync(int count)
        {
            var popularTags = await _tagRepository.GetPopularTagsAsync(count);
            return _mapper.Map<IEnumerable<TagDto>>(popularTags);
        }
    }
}
