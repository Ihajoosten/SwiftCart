
namespace User.Application.Dto.Address
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        // Navigational Property to User
        public Core.Entities.User User { get; set; }
    }
}
