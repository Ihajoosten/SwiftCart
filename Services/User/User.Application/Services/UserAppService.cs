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

        public UserAppService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
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

        public async Task<IEnumerable<RoleDto>> GetRolesForUserAsync(int userId)
        {
            var roles = await _userRepository.GetRolesForUserAsync(userId);
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<IEnumerable<UserDto>> GetUsersInRoleAsync(string roleName)
        {
            var users = await _userRepository.GetByRoleAsync(roleName);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
