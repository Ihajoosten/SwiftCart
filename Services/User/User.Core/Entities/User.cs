using User.Core.Entities.Base;

namespace User.Core.Entities
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public UserRole? Role { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        // Navigation properties for related address, phone numbers, and roles
        public ICollection<Address>? Addresses { get; set; }
        public ICollection<PhoneNumber>? PhoneNumbers { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Customer,
        Sales,
        CustomerSupport,
        Marketing
    }
}
