using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.DAL;

namespace TruckTransportManegment.Areas.MainPages.Controllers
{
    [Area("MainPages")]
    public class BookingController : Controller
    {
        public IActionResult Order()
        {
            ViewBag.Title = "Order";
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            ViewBagData();
            return View(booking_DALBase.Order_SelectAll());
        }
        [CheckAccess2]
        public IActionResult Booking()
        {
            ViewBag.Title = "Booking";
            ViewBagData();
            return View();
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
