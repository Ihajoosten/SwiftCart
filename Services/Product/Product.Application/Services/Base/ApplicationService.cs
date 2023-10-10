using AutoMapper;
using Product.Application.Interfaces.Base;
using Product.Core.IRepositories.Base;

namespace Product.Application.Services.Base
{
    public class ApplicationService<TEntity, TDto, TCreateDto, TUpdateDto> : IApplicationService<TDto, TCreateDto, TUpdateDto> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public ApplicationService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> CreateAsync(TCreateDto createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            entity = await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<bool> UpdateAsync(int id, TUpdateDto updateDto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(updateDto, entity);

            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            return await _repository.DeleteAsync(entity);
        }
    }
}
