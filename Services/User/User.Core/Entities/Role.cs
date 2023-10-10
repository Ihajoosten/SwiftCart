using User.Core.Entities.Base;

namespace User.Core.Entities
{
    public class Role : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
