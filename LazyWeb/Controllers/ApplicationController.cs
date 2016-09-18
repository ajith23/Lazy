using LazyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyWeb.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
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

        private void UpdateViewBag()
        {
            ViewBag.UserAccess = Utility.GetUserAccess(Session["LazyKey"] == null ? string.Empty : Session["LazyKey"].ToString());
            var path = HttpContext.Server.MapPath("~/Data/ApplicationData.txt");
            ViewBag.ApplicationList = Application.ReadData(path);
        }

        private ActionResult HandleNoAuth()
        {
            return RedirectToAction("Index", "Error", new { error = Constants.NoAuthMessage });
        }
    }
}