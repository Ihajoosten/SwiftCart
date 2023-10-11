using AutoMapper;
using User.Application.Dto.User;
using User.Application.Interfaces;
using User.Application.Services.Base;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class AppUserService : ApplicationService<Core.Entities.User, UserDto, CreateUserDto, UpdateUserDto>, IAppUserService
    {
        private readonly IUserRepository _userRepository;

        public AppUserService(IUserRepository userRepository, IMapper mapper)
            : base(userRepository, mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user != null ? _mapper.Map<UserDto>(user) : null;
        }

        public async Task<UserDto?> GetByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            return user != null ? _mapper.Map<UserDto>(user) : null;
        }

        public async Task AddUserRoleAsync(UserRoleDto userRoleDto)
        {
            await _userRepository.AddUserRoleAsync(userRoleDto.UserId, userRoleDto.Role);
        }

        public async Task UpdateUserRoleAsync(UserRoleDto userRoleDto)
        {
            await _userRepository.UpdateUserRoleAsync(userRoleDto.UserId, userRoleDto.Role);
        }

        public async Task RemoveUserRoleAsync(UserRoleDto userRoleDto)
        {
            await _userRepository.RemoveUserRoleAsync(userRoleDto.UserId, userRoleDto.Role);
        }
    }
}
