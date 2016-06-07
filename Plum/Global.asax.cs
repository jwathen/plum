using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Plum.Controllers;
using RazorGenerator.Mvc;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;

namespace Plum
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static bool IS_TEST = false;
        protected static bool ENABLE_MINI_PROFILER = bool.Parse(AppSettings.EnableMiniProfiler);

        protected void Application_Start()
        {
            MiniProfilerEF6.Initialize();

            //Database.SetInitializer<Models.AppDataContext>(null);
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

        protected void InitializeMiniProfiler()
        {
            if (ENABLE_MINI_PROFILER)
            {                
                
                this.BeginRequest += (sender, e) => MiniProfiler.Start();
                this.EndRequest += (sender, e) => MiniProfiler.Stop();
            }
        }

        protected void Application_BeginRequest()
        {
            if (ENABLE_MINI_PROFILER)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            if (ENABLE_MINI_PROFILER)
            {                
                MiniProfiler.Stop();
            }
        }
    }
}
