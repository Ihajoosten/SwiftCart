
namespace User.Application.Dto.PhoneNumber
{
    public class PhoneNumberDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }

        // Navigation property for related user
        public Core.Entities.User User { get; set; }
    }
}
