﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AttributeRouting.Web.Mvc;
using Plum.Controllers;

namespace Plum
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapAttributeRoutes(x =>
            {
                x.AddRoutesFromAssemblyOf<HomeController>();
                x.AppendTrailingSlash = true;
                x.UseLowercaseRoutes = true;
            });
        }
    }
}