using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using AttributeRouting.Web.Mvc;
using Plum.Controllers;
using RazorGenerator.Mvc;

namespace Plum
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static bool IS_TEST = false;

        protected void Application_Start()
        {
            Database.SetInitializer<Models.ApplicationDataContext>(null);
            FluentValidation.Mvc.FluentValidationModelValidatorProvider.Configure();

            RegisterRoutes(RouteTable.Routes);
            RegisterViewEngines(ViewEngines.Engines);
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

        protected void RegisterViewEngines(ViewEngineCollection engines)
        {
            var engine = new PrecompiledMvcEngine(typeof(MvcApplication).Assembly)
            {
                UsePhysicalViewsIfNewer = bool.Parse(AppSettings.UsePhysicalViewsIfNewer),
                FileExtensions = new[] { "cshtml" }
            };

            engines.Clear();
            engines.Insert(0, engine);

            // StartPage lookups are done by WebPages. 
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
        }
    }
}
