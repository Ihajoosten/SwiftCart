
using User.Core.Entities;

namespace User.Application.Dto.User
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole? Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
