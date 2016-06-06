using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyWeb.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            if (Utility.IsAuthenticated(Session["LazyKey"] == null ? string.Empty : Session["LazyKey"].ToString()))
            {
                UpdateViewBag();
                return View();
            }
            else
            {
                return HandleNoAuth();
            }
        }

        [HttpPost]
        public JsonResult SaveSettings(string size, string orientation, string margin)
        {
            try
            {
                Session["PageSize"] = size;
                Session["PageOrientation"] = orientation;
                Session["PageMargin"] = margin;
                return Json("Settings saved successfully. All your new settings will be applied here after.", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Something happend. Please try again.", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetSettings()
        {
            try
            {
                var size = Session["PageSize"] != null ? Session["PageSize"].ToString() : "Letter";
                var orientation = Session["PageOrientation"] != null ? Session["PageOrientation"].ToString() : "Portrait";
                var margin = Session["PageMargin"] != null ? Convert.ToInt32(Session["PageMargin"].ToString()) : 25;
                return Json(new { size = size, orientation = orientation, margin = margin }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Something happend. Please try again.", JsonRequestBehavior.AllowGet);
            }
        }

        private void UpdateViewBag()
        {
            ViewBag.PageSize = Session["PageSize"] != null ? Session["PageSize"].ToString() : "Letter";
            ViewBag.PageOrientation = Session["PageOrientation"] != null ? Session["PageOrientation"].ToString() : "Portrait";
            ViewBag.PageMargin = Session["PageMargin"] != null ? Convert.ToInt32(Session["PageMargin"].ToString()) : 25;
        }
        private ActionResult HandleNoAuth()
        {
            return RedirectToAction("Index", "Error", new { error = Constants.NoAuthMessage });
        }
    }
}