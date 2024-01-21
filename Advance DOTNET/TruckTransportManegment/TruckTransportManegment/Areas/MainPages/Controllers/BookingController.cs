using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.Areas.Login.Models;
using TruckTransportManegment.Areas.MainPages.Models;
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
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            ViewBagData();
            return View(booking_DALBase.Add_Edit_Order());
        }

        public IActionResult Save(BookingModel bookingModel) 
        {
            bookingModel.UserID= Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            booking_DALBase.Save(bookingModel);
            return RedirectToAction("Order");
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
