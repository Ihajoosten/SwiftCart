using Auth.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Dto.Auth
{
    public class UpdateCredentialsDto
    {
        [Required]
        public int Id { get; set; }
        public string NewEmail { get; set; }
        public string NewUsername { get; set; }
        public string NewPassword { get; set; }
        public UserRole NewRole { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
