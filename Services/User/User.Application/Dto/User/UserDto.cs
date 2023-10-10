
using User.Application.Dto.UserRole;

namespace User.Application.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; } = new List<UserRoleDto>();
    }
}
