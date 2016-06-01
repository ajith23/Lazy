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
            ViewBag.TemplateList = Cover.GetDummyData();
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.TemplateList = Cover.GetDummyData();
            return View();
        }

        [HttpGet]
        public JsonResult FetchCoverTemplate(int id)
        {
            var template = Cover.GetDummyData().Where(c => c.Id == id).FirstOrDefault();
            if (template != null)
            {
                template.Template = Server.HtmlEncode(template.Template);
                return Json(template, JsonRequestBehavior.AllowGet);
            }
            else
                return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}