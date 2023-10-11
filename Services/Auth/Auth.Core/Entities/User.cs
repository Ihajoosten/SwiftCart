using Auth.Core.Entities.Base;

namespace Auth.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property for related tokens
        public ICollection<Token> Tokens { get; set; }
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
