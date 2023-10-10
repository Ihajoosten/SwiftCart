using AutoMapper;
using User.Application.Dto.Role;
using User.Application.Dto.User;
using User.Application.Dto.UserRole;
using User.Application.Interfaces;
using User.Application.Services.Base;
using User.Core.Entities;
using User.Core.IRepositories;

namespace User.Application.Services
{
    public class UserRoleAppService : ApplicationService<UserRole, UserRoleDto, CreateUserRoleDto, UpdateUserRoleDto>, IUserRoleAppService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleAppService(IUserRoleRepository userRoleRepository, IMapper mapper) : base(userRoleRepository, mapper)
        {
            _userRoleRepository = userRoleRepository ?? throw new ArgumentNullException(nameof(userRoleRepository));
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


