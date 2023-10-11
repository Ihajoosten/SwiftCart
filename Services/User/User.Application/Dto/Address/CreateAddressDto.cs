
namespace User.Application.Dto.Address
{
    public class CreateAddressDto
    {
        public int UserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
