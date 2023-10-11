using User.Core.Entities.Base;

namespace User.Core.Entities
{
    public class PhoneNumber : BaseEntity
    {
        public required int UserId { get; set; }
        public required string Number { get; set; }
        public required string Type { get; set; }

        // Navigation property for related user
        public User? User { get; set; }
    }
}
