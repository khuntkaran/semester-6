using Microsoft.AspNetCore.Mvc;
using DriverTransportManegment.DAL;
using TruckTransportManegment.DAL;
using TruckTransportManegment.Areas.MainPages.Models;

namespace DriverTransportManegment.Areas.MainPages.Controllers
{
    [CheckAccess]
    [Area("MainPages")]
    public class DriverController : Controller
    {

        [CheckAccess1]
        public IActionResult Driver()
        {
            ViewBag.Title = "Driver";
            ViewBagData();
            Driver_DALBase driver_DALBase = new Driver_DALBase();
            return View(driver_DALBase.Driver_SelectAll());
        }
        [CheckAccess1]
        public IActionResult DriverAddEdit(int? DriverID)
        {
            ViewBagData();
            try
            {
                ViewBag.Title = "Driver";
                if (DriverID != null)
                {
                    ViewBag.Data = "For Edit";

                    ViewBagData();
                    Driver_DALBase driver_DALBase = new Driver_DALBase();
                    return View(driver_DALBase.Driver_SelectByID((int)DriverID));
                }
                else
                {
                    ViewBag.Data = "For Add";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("Driver");

            }
        }
        public IActionResult Save(DriverModel driverModel)
        {
            try
            {
                Driver_DALBase driver_DALBase = new Driver_DALBase();
                driver_DALBase.Driver_AddEdit(driverModel);
                return RedirectToAction("Driver");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Driver");
            }
        }
        public IActionResult DriverDelete(int DriverID)
        {
            Driver_DALBase driver_DALBase = new Driver_DALBase();
            driver_DALBase.Driver_Delete(DriverID);
            return RedirectToAction("Driver");
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
