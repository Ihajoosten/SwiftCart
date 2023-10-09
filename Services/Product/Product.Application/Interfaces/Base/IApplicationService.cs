using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces.Base
{
    public interface IApplicationService<TDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task UpdateAsync(int id, TUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
