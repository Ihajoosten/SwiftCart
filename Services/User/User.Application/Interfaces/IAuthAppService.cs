
namespace User.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task<string?> AuthenticateUserAsync(string username, string password);
    }
}
