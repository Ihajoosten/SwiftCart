
using System.ComponentModel.DataAnnotations;

namespace User.Application.Dto.User
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
