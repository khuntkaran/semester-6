using Microsoft.AspNetCore.Mvc;

namespace TruckTransportManegment.Areas.Login.Controllers
{
    [Area("Login")]
    public class ValidationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
