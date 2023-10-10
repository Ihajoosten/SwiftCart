
namespace Order.Application.Dto.ShippingDetails
{
    public class CreateShippingDetailsDto
    {
        public int OrderId { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}
