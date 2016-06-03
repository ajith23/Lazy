using LazyWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (Utility.IsAuthenticated(Session["LazyKey"]==null ? string.Empty: Session["LazyKey"].ToString()))
            {
                UpdateViewBag();
                return View();
            }
            else
            {
                return HandleNoAuth();
            }
        }

        public ActionResult Edit(int id)
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

        [HttpGet]
        public JsonResult FetchCoverTemplate(int id)
        {
            if (Utility.IsAuthenticated(Session["LazyKey"] == null ? string.Empty : Session["LazyKey"].ToString()))
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
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SaveEditCoverTemplate(string id, string version, string template)
        {
            if (Utility.IsAuthenticated(Session["LazyKey"] == null ? string.Empty : Session["LazyKey"].ToString()))
            {
                var coverId = 0;
                if (int.TryParse(id, out coverId))
                {
                    if (coverId == 0)
                    {
                        //create
                        var coverList = (List<Cover>)Session["CoverList"];
                        var newId = coverList.Count + 1;
                        coverList.Add(new Cover { Id = newId, Version = version, Template = template });
                        lastEditedId = newId;
                        return Json("Your new template is created. You will now be redirected to preview your created template.", JsonRequestBehavior.AllowGet);
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
            else
            {
                return Json("Failed. Not Authenticated.", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GeneratePDF(string cover)
        {
            if (Utility.IsAuthenticated(Session["LazyKey"] == null ? string.Empty : Session["LazyKey"].ToString()))
            {
                try
                {
                    var byteArray = Utility.GeneratePDF(HttpUtility.HtmlDecode(cover));
                    //return new FileContentResult(Convert.ToBase64String(byteArray), "application/pdf");
                    return Json(Convert.ToBase64String(byteArray), JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    //return new FileContentResult(null, "application/pdf");
                    return Json("Something went wrong.", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Failed. Not Authenticaed.", JsonRequestBehavior.AllowGet);
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

        private ActionResult HandleNoAuth()
        {
            return RedirectToAction("Index", "Error", new { error = Utility.NoAuthMessage });
        }
    }
}