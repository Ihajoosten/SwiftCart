using AutoMapper;
using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Interfaces;
using User.Application.Services.Base;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class UserAppService : ApplicationService<Core.Entities.User, UserDto, CreateUserDto, UpdateUserDto>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordAppService _passwordService;
        public UserAppService(IUserRepository userRepository, IMapper mapper, IPasswordAppService passwordService) : base(userRepository, mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordService = passwordService;
        }

        public async Task<UserDto?> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public override async Task<UserDto> CreateAsync(CreateUserDto createDto)
        {
            createDto.Password = _passwordService.HashPassword(createDto.Password);

            var entity = _mapper.Map<Core.Entities.User>(createDto);
            entity = await _repository.AddAsync(entity);

            return _mapper.Map<UserDto>(entity);
        }
    }
}
