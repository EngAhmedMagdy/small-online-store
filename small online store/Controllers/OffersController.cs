﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace small_online_store.Controllers
{
    public class OffersController : Controller
    {
        // GET: Offers
        public ActionResult Index()
        {
            return View();
        }
    }
}