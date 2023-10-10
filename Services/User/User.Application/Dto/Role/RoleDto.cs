
using User.Application.Dto.UserRole;

namespace User.Application.Dto.Role
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; } = new List<UserRoleDto>();
    }
}
