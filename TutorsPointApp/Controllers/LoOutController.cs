﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorsPointApp.Controllers
{
    public class LoOutController : Controller
    {
        
        public ActionResult Index()
        {
            Session["tutor"] = "False";
            Session["parent"] = "False";
            return RedirectToAction("Index", "Login");
        }
    }
}