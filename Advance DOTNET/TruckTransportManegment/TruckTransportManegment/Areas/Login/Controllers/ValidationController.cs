using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.Areas.Login.Models;
using TruckTransportManegment.DAL;

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

        public IActionResult SubmitLogin(UserModel userModel)
        {
            Login_DALBase login_DALBase = new Login_DALBase();
            userModel = login_DALBase.Login(userModel.UserName, userModel.Password);
            if (userModel?.UserID != null && userModel?.UserID > 0 )
            {
                HttpContext.Session.SetInt32("UserID", userModel.UserID);
                HttpContext.Session.SetString("IsAdmin", userModel.IsAdmin.ToString());
               return RedirectToAction("Home", "Pages", new {  area="MainPages"});
            }

            return RedirectToAction("Login");
        }
        public IActionResult SubmitRegistration(UserModel userModel)
        {
            Login_DALBase login_DALBase = new Login_DALBase();
            bool verify = login_DALBase.Registration(userModel) ;
            if (verify == true)
            {
                return RedirectToAction("Login" );
            }

            return RedirectToAction("Registration");
        }
        public IActionResult Successful()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            return View();
        }
    }
}
