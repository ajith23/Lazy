using LazyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyWeb.Controllers
{
    public class CoverController : Controller
    {
        // GET: Cover
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.TemplateList = Cover.GetDummyData();
            return View();
        }

        [HttpGet]
        public ActionResult FetchCoverTemplates(int id)
        {
            return Json("test");
        }
    }
}