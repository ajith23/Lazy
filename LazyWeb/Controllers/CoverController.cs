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
            UpdateViewBag();
            return View();
        }

        public ActionResult Edit(int id)
        {
            UpdateViewBag();
            return View();
        }

        [HttpGet]
        public JsonResult FetchCoverTemplate(int id)
        {
            var template = FetchCover(id);
            if (template != null)
            {
                //template.Template = Server.HtmlEncode(template.Template);
                return Json(template, JsonRequestBehavior.AllowGet);
            }
            else
                return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveEditCoverTemplate(string id, string version, string template)
        {
            var coverId = 0;
            if(int.TryParse(id, out coverId))
            {
                if (coverId == 0)
                {
                    //create
                    var coverList = (List<Cover>)Session["CoverList"];
                    var newId = coverList.Count + 1;
                    coverList.Add(new Cover { Id = newId, Version = version, Template = template });
                    lastEditedId = newId;
                    return Json("Your new template is created. You will now be redirected to preview your created template." , JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //update
                    var cover = FetchCover(coverId);
                    cover.Template = template;
                    cover.Version = version;
                    lastEditedId = coverId;
                    return Json("Your new template is updated. You will now be redirected to preview your updated template.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Failed. Invalid ID passed.", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public FileStreamResult GeneratePDF(string cover)
        {
            try
            {
                var pdfStream = Utility.GeneratePDF(HttpUtility.HtmlDecode(cover));
                return new FileStreamResult(pdfStream, "application/pdf");
                //return Json("PDF generated and saved.", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new FileStreamResult(null, "application/pdf");
                //return Json("Failed. Invalid ID passed.", JsonRequestBehavior.AllowGet);
            }
        }

        private Cover FetchCover(int id)
        {
            if (Session["CoverList"] != null)
            {
                return ((List<Cover>)Session["CoverList"]).Where(c => c.Id == id).FirstOrDefault();
            }
            else
            {
                Session["CoverList"] = Cover.GetDummyData();
                return Cover.GetDummyData().Where(c => c.Id == id).FirstOrDefault();
            }
        }

        private static int lastEditedId = 0;
        private void UpdateViewBag()
        {
            if (Session["CoverList"] != null)
            {
                ViewBag.TemplateList = (List<Cover>)Session["CoverList"];
            }
            else
            {
                Session["CoverList"] = Cover.GetDummyData();
                ViewBag.TemplateList = (List<Cover>)Session["CoverList"];
            }
            ViewBag.LastEditedId = lastEditedId;
        }
    }
}