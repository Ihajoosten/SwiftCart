
using User.Core.Entities;

namespace User.Application.Dto.User
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public UserRole Role { get; set; }
    }
}
