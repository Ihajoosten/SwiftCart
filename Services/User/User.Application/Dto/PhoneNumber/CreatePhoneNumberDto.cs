
namespace User.Application.Dto.PhoneNumber
{
    public class CreatePhoneNumberDto
    {
        public int UserId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
    }
}
