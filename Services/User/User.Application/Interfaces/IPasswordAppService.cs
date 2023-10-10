
namespace User.Application.Interfaces
{
    public interface IPasswordAppService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}
