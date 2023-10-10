
using System.ComponentModel.DataAnnotations;

namespace User.Application.Dto.Role
{
    public class CreateRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
