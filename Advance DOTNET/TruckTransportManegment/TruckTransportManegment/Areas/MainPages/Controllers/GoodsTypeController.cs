using Microsoft.AspNetCore.Mvc;
using TruckTransportManegment.Areas.MainPages.Models;
using TruckTransportManegment.DAL;
using TruckTransportManegment.DAL.CheckAccess;

namespace TruckTransportManegment.Areas.MainPages.Controllers
{
    [LoginAccess]
    [Area("MainPages")]
    public class GoodsTypeController : Controller
    {
        [AdminAccess]
        public IActionResult GoodsType()
        {
            ViewBag.Title = "GoodsType";
            ViewBagData();
            GoodsType_DALBase goodsType_DALBase = new GoodsType_DALBase();
            return View(goodsType_DALBase.GoodsType_SelectAll());
        }
        [AdminAccess]
        public IActionResult GoodsTypeAddEdit(int? GoodsTypeID)
        {
            ViewBagData();
            try
            {
                ViewBag.Title = "GoodsType";
                if (GoodsTypeID != null)
                {
                    ViewBag.Data = "For Edit";

                    ViewBagData();
                    GoodsType_DALBase goodsType_DALBase = new GoodsType_DALBase();
                    return View(goodsType_DALBase.GoodsType_SelectByID((int)GoodsTypeID));
                }
                else
                {
                    ViewBag.Data = "For Add";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View("GoodsType");

            }
        }
        public IActionResult Save(GoodsTypeModel goodsTypeModel)
        {
            try
            {
                GoodsType_DALBase goodsType_DALBase = new GoodsType_DALBase();
                goodsType_DALBase.GoodsType_AddEdit(goodsTypeModel);
                return RedirectToAction("GoodsType");
            }
            catch (Exception ex)
            {
                return RedirectToAction("GoodsType");
            }
        }
        public IActionResult GoodsTypeDelete(int GoodsTypeID)
        {
            GoodsType_DALBase goodsType_DALBase = new GoodsType_DALBase();
            goodsType_DALBase.GoodsType_Delete(GoodsTypeID);
            return RedirectToAction("GoodsType");
        }
        public void ViewBagData()
        {
            ViewBag.UserID = HttpContext.Session.GetInt32("UserID");
            ViewBag.IsAdmin = HttpContext.Session.GetString("IsAdmin");
        }
    }
}
