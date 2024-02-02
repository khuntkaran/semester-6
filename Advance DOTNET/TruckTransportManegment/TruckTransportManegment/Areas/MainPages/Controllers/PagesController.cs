using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.DAL;
using TruckTransportManegment.DAL.CheckAccess;

namespace TruckTransportManegment.Areas.MainPages.Controllers
{
    [LoginAccess]
    [Area("MainPages")]
    public class PagesController : Controller
    {
        
        public IActionResult Home()
        {
            ViewBag.Title = "Home";
            ViewBagData();
            Statestics_DALBase statestics_DALBase = new Statestics_DALBase();
            return View(statestics_DALBase.Statestics_SelectAll());
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
