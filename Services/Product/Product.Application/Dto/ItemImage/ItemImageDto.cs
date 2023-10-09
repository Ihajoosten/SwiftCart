
namespace Product.Application.Dto.ItemImage
{
    public class ItemImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int ProductId { get; set; }
        public Core.Entities.Product Product { get; set; }
    }
}
