using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult SecureLogin(string key)
        {
            if (Utility.IsAuthenticated(key))
            {
                Session["LazyKey"] = key;
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["LazyKey"] = null;
                return Json("Failure", JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult SecureLogout()
        {
            Session["LazyKey"] = null;
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}