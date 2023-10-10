
namespace User.Application.Interfaces.Base
{
    public interface IApplicationService<TDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task<bool> UpdateAsync(int id, TUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
