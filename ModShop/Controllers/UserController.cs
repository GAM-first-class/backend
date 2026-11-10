using Microsoft.AspNetCore.Mvc;

namespace ModShop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
