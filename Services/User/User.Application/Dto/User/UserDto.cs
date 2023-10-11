using User.Application.Dto.Address;
using User.Application.Dto.PhoneNumber;
using User.Core.Entities;

namespace User.Application.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties for related address, phone numbers, and roles
        public ICollection<AddressDto> Addresses { get; set; }
        public ICollection<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
