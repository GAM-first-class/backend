using Microsoft.AspNetCore.Mvc;

namespace ModShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
