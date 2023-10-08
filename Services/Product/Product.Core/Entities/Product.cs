
namespace Product.Core.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Summary { get; set; }
        public required string Description { get; set; }
        public required string ImageFile { get; set; }
        public required ProductBrand ProductBrand { get; set; }
        public required ProductType ProductType { get; set; }
        public required decimal Price { get; set; }
    }
}
