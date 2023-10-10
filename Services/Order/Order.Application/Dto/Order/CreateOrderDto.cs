
namespace Order.Application.Dto.Order
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public int ShippingDetailsId { get; set; }
    }
}
