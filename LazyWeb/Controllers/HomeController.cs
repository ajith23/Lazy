﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LazyWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Utility.IsAuthenticated(Session["LazyKey"] == null ? string.Empty : Session["LazyKey"].ToString()))
            {
                return View();
            }
            else
            {
                return HandleNoAuth();
            }
        }

        private ActionResult HandleNoAuth()
        {
            return RedirectToAction("Index", "Error", new { error = Constants.NoAuthMessage});
        }
    }
}