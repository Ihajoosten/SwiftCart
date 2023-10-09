using Product.Application.Dto.Category;
using Product.Application.Interfaces.Base;

namespace Product.Application.Interfaces
{
    public interface IAppCategoryService : IApplicationService<CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        Task<IEnumerable<CategoryDto?>?> GetMainCategoriesAsync();
    }
}
