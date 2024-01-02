using Microsoft.AspNetCore.Mvc;

namespace TruckTransportManegment.Areas.MainPages.Controllers
{
    [Area("MainPages")]
    public class PagesController : Controller
    {
        
        public IActionResult Home()
        {
            ViewBag.Title = "Home";
            ViewBagData();
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About";
            ViewBagData();
            return View();
        }
        public IActionResult Services()
        {
            ViewBag.Title = "Services";
            ViewBagData();
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBagData();
            return View();
        }
        public IActionResult Order()
        {
            ViewBag.Title = "Order";
            ViewBagData();
            return View();
        }
        public IActionResult Booking()
        {
            ViewBag.Title = "Booking";
            ViewBagData();
            return View();
        }
        public IActionResult Truck()
        {
            ViewBag.Title = "Truck";
            ViewBagData();
            return View();
        }
        public IActionResult Driver()
        {
            ViewBag.Title = "Driver";
            ViewBagData();
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Validation",new {area="Login"});
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
