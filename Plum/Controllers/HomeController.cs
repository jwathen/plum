﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace Plum.Controllers
{
    public partial class HomeController : AppControllerBase
    {
        [GET("")]
        public virtual ActionResult Index()
        {
            return View();
        }

        [GET("page_not_found")]
        public virtual ActionResult NotFound()
        {
            return View();
        }

        [GET("error")]
        public virtual ActionResult Error()
        {
            return View();
        }

        [GET("not_authorized")]
        public virtual ActionResult NotAuthorized()
        {
            return View();
        }
    }
}