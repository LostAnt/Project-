﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Search(String q)
        {
            return View();
        }
    }
}