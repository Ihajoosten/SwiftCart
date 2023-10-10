using Microsoft.AspNetCore.Mvc;

namespace User.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
