using User.Core.Entities.Base;

namespace User.Core.Entities
{
    public class Address : BaseEntity
    {
        public required int UserId { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }

        // Navigation property for related user
        public User? User { get; set; }
    }
}
