using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.Areas.Login.Models;
using TruckTransportManegment.Areas.MainPages.Models;
using TruckTransportManegment.DAL;
using TruckTransportManegment.DAL.CheckAccess;

namespace TruckTransportManegment.Areas.MainPages.Controllers
{
    [LoginAccess]
    [Area("MainPages")]
    public class BookingController : Controller
    {
        public IActionResult Order()
        {
            ViewBag.Title = "Order";
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            ViewBagData();
            int? userid = null;
            if (!Convert.ToBoolean(HttpContext.Session.GetString("IsAdmin")))
            {
                userid= Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            }
            
                
            return View(booking_DALBase.Order_SelectAll(userid));
        }
        [UserAccess]
        public IActionResult Booking(int? BookingID)
        {
            ViewBag.Title = "Booking";
            if(BookingID != null)
            {
                ViewBag.Data = "For Edit";
            }
            else
            {
                ViewBag.Data = "For Add";
            }
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            ViewBagData();
            return View(booking_DALBase.Add_Edit_Order(BookingID));
        }

        public IActionResult Save(BookingModel bookingModel) 
        {
            bookingModel.UserID= Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            booking_DALBase.Save(bookingModel);
            return RedirectToAction("Order");
        }

        public IActionResult CancleBooking(int BookingID)
        {
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            booking_DALBase.Order_Delete(BookingID);
            return RedirectToAction("Order");
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
