﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using WaitlistApp.Controllers;
using WaitlistApp.Services;
using RazorGenerator.Mvc;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;

namespace WaitlistApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static bool IS_TEST = false;
        protected static bool ENABLE_MINI_PROFILER = bool.Parse(AppSettings.EnableMiniProfiler);

        protected void Application_Start()
        {
            MiniProfilerEF6.Initialize();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.AppDataContext, Migrations.Configuration>());
            FluentValidation.Mvc.FluentValidationModelValidatorProvider.Configure();

            RegisterRoutes(RouteTable.Routes);
            RegisterViewEngines(ViewEngines.Engines);
        }

        protected void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.AppendTrailingSlash = true;
            routes.MapMvcAttributeRoutes();

            var secrets = new AppSecrets(Server.MapPath("~/App_Data/Secrets.json"));
            routes.MapRoute("IncomingSms", secrets.PlivoIncomingSmsRoute, MVC.Plivo.IncomingSms());
        }

        protected void RegisterViewEngines(ViewEngineCollection engines)
        {
            var razorViewEngine = new RazorViewEngine();
            razorViewEngine.FileExtensions = new[] { "cshtml" };

            var precompiledViewEngine = new PrecompiledMvcEngine(typeof(MvcApplication).Assembly)
            {
                UsePhysicalViewsIfNewer = bool.Parse(AppSettings.UsePhysicalViewsIfNewer),
                FileExtensions = new[] { "cshtml" }
            };

            engines.Clear();
            engines.Add(precompiledViewEngine);
            engines.Add(razorViewEngine);

            // StartPage lookups are done by WebPages. 
            VirtualPathFactoryManager.RegisterVirtualPathFactory(precompiledViewEngine);
        }

        protected void Application_BeginRequest()
        {
            if (ENABLE_MINI_PROFILER)
            {
                MiniProfiler.StartNew();
            }
        }

        protected void Application_EndRequest()
        {
            if (ENABLE_MINI_PROFILER)
            {                
                MiniProfiler.Current?.Stop();
            }
        }
    }
}
