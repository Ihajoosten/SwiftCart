using User.Core.Entities.Base;

namespace User.Core.Entities
{
    public class UserRole : BaseEntity
    {
        public required int UserId { get; set; }
        public virtual User User { get; set; }

        public required int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
