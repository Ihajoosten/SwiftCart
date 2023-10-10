using AutoMapper;
using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Dto.UserRole;
using User.Application.Interfaces;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class UserRoleAppService : IUserRoleAppService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public UserRoleAppService(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public async Task<UserRoleDto> AddUserToRoleAsync(int userId, int roleId)
        {
            var created = await _userRoleRepository.AddUserToRoleAsync(userId, roleId);
            return _mapper.Map<UserRoleDto>(created);
        }

        public async Task<bool> RemoveUserFromRoleAsync(int userId, int roleId)
        {
            return await _userRoleRepository.RemoveUserFromRoleAsync(userId, roleId);
        }

        public async Task<IEnumerable<RoleDto>> GetRolesForUserAsync(int userId)
        {
            var roles = await _userRoleRepository.GetRolesForUserAsync(userId);
            var roleDtos = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return roleDtos;
        }

        public async Task<IEnumerable<UserDto>> GetUsersInRoleAsync(string roleName)
        {
            var users = await _userRoleRepository.GetUsersInRoleAsync(roleName);
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }
    }
}


