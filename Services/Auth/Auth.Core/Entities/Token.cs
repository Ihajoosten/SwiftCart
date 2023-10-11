using Auth.Core.Entities.Base;

namespace Auth.Core.Entities
{
    public class Token : BaseEntity
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }

        // Navigation property for related user
        public User User { get; set; }
    }
}
