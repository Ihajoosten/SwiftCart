using Product.Core.Entities.Base;

namespace Product.Core.Entities
{
    public class Review : BaseEntity
    {
        public required int Rating { get; set; }
        public required string Comment { get; set; }
        public required int UserId { get; set; }

        // Foreign key
        public required int ProductId { get; set; }

        // Navigation property
        public Product Product { get; set; }
    }
}
