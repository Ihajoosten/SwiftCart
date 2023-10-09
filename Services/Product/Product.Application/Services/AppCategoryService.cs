using AutoMapper;
using Product.Application.Dto.Brand;
using Product.Application.Dto.Category;
using Product.Application.Interfaces;
using Product.Application.Services.Base;
using Product.Core.Entities;
using Product.Core.IRepositories;

namespace Product.Application.Services
{
    public class AppCategoryService : ApplicationService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>, IAppCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public AppCategoryService(ICategoryRepository categoryRepository, IMapper mapper)
            : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IEnumerable<CategoryDto?>?> GetMainCategoriesAsync()
        {
            var mainCategories = await _categoryRepository.GetMainCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(mainCategories);
        }
    }
}
