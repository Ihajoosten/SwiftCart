using User.Application.Dto.Role;
using User.Application.Dto.User;

namespace User.Application.Dto.UserRole
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
