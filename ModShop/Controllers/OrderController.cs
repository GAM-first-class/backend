using Microsoft.AspNetCore.Mvc;

namespace ModShop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
