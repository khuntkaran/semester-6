using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.Areas.MainPages.Models;
using TruckTransportManegment.DAL;
using TruckTransportManegment.DAL.CheckAccess;

namespace TruckTransportManegment.Areas.MainPages.Controllers
{
    [LoginAccess]
    [Area("MainPages")]
    public class CityController : Controller
    {
        [AdminAccess]
        public IActionResult City()
        {
            ViewBag.Title = "City";
            ViewBagData();
            City_DALBase city_DALBase = new City_DALBase();
            return View(city_DALBase.City_SelectAll());
        }
        [AdminAccess]
        public IActionResult CityAddEdit(int? CityID)
        {
            ViewBagData();
            try
            {
                ViewBag.Title = "City";
                if (CityID != null)
                {
                    ViewBag.Data = "For Edit";

                    ViewBagData();
                    City_DALBase city_DALBase = new City_DALBase();
                    return View(city_DALBase.City_SelectByID((int)CityID));
                }
                else
                {
                    ViewBag.Data = "For Add";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("City");

            }
        }
        public IActionResult Save(CityModel cityModel)
        {
            try
            {
                City_DALBase city_DALBase = new City_DALBase();
                city_DALBase.City_AddEdit(cityModel);
                return RedirectToAction("City");
            }
            catch (Exception ex)
            {
                return RedirectToAction("City");
            }
        }
        public IActionResult CityDelete(int CityID)
        {
            City_DALBase city_DALBase = new City_DALBase();
            city_DALBase.City_Delete(CityID);
            return RedirectToAction("City");
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
