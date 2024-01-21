using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.Areas.MainPages.Models;
using TruckTransportManegment.DAL;
using TruckTransportManegment.DAL.CheckAccess;

namespace TruckTransportManegment.Areas.MainPages.Controllers
{
    [LoginAccess]
    [Area("MainPages")]
    public class TruckController : Controller
    {
        [AdminAccess]
        public IActionResult Truck()
        {
            ViewBag.Title = "Truck";
            ViewBagData();
            Truck_DALBase truck_DALBase = new Truck_DALBase();
            return View(truck_DALBase.Truck_SelectAll());
        }
        [AdminAccess]
        public IActionResult TruckAddEdit(int? TruckID)
        {
            ViewBagData();
            try
            {
                ViewBag.Title = "Truck";
                if (TruckID != null)
                {
                    ViewBag.Data = "For Edit";

                    ViewBagData();
                    Truck_DALBase truck_DALBase = new Truck_DALBase();
                    return View(truck_DALBase.Truck_SelectByID((int)TruckID));
                }
                else
                {
                    ViewBag.Data = "For Add";
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View("Truck");

            }
        }
        public IActionResult Save(TruckModel truckModel)
        {
            try
            {
                Truck_DALBase truck_DALBase = new Truck_DALBase();
                truck_DALBase.Truck_AddEdit(truckModel);
                return RedirectToAction("Truck");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Truck");
            }
        }
        public IActionResult TruckDelete(int TruckID)
        {
            Truck_DALBase truck_DALBase = new Truck_DALBase();
            truck_DALBase.Truck_Delete(TruckID);
            return RedirectToAction("Truck");
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
