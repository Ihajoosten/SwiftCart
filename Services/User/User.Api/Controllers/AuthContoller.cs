using Microsoft.AspNetCore.Mvc;

namespace User.Api.Controllers
{
    public class AuthContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
