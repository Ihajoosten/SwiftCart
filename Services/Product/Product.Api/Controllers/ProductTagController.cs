using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
    public class ProductTagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
