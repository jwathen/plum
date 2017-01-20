using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using WaitlistApp.Tests.TestHelpers.Mvc.TestViewEngine;
using RazorGenerator.Mvc;

namespace WaitlistApp.Tests.TestHelpers.Mvc
{
    public static class WebApplicationTestEnvironment
    {
        private static string _virtualDirectory;
        private static Assembly _applicationAssembly;
        private static Type _applicationType;
        private static string _phyiscalDirectory;

        public static void Setup<TController>()
        {
            SetHttpApplicationType(typeof(TController));
            MapMvcAttributeRoutesForTesting<TController>(RouteTable.Routes);
            SetupViewEngines<TController>(ViewEngines.Engines);
            SetupT4MvcVirtualPathResolver();
        }

        public static string VirtualDirectory
        {
            get
            {
                return _virtualDirectory;
            }
        }

        public static string PhyiscalDirectory { get { return _phyiscalDirectory; } }

        private static void SetHttpApplicationType(Type controller)
        {
            Type type = (from x in controller.Assembly.GetExportedTypes()
                         where typeof(HttpApplication).IsAssignableFrom(x)
                         select x).Single();
            _applicationType = type;
            _applicationAssembly = type.Assembly;
        }

        public static void MapMvcAttributeRoutesForTesting<TController>(RouteCollection routeCollection)
        {
            routeCollection.Clear();
            var controllerTypes = (from type in _applicationAssembly.GetExportedTypes()
                                    .Concat(typeof(TController).Assembly.GetExportedTypes())
                                   where
                                       type != null && type.IsPublic
                                       && type.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
                                       && !type.IsAbstract && typeof(IController).IsAssignableFrom(type)
                                   select type).ToList();

            var attributeRoutingAssembly = typeof(RouteCollectionAttributeRoutingExtensions).Assembly;
            var attributeRoutingMapperType =
                attributeRoutingAssembly.GetType("System.Web.Mvc.Routing.AttributeRoutingMapper");

            var mapAttributeRoutesMethod = attributeRoutingMapperType.GetMethod(
                "MapAttributeRoutes",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(RouteCollection), typeof(IEnumerable<Type>) },
                null);

            mapAttributeRoutesMethod.Invoke(null, new object[] { routeCollection, controllerTypes });
        }

        private static void SetupViewEngines<T>(ViewEngineCollection viewEngineCollection)
        {
            viewEngineCollection.Clear();
            var viewEngine = new TestCompositePrecompiledMvcEngine(
                PrecompiledViewAssembly.OfType<T>(false, true));
            viewEngineCollection.Add(viewEngine);
            viewEngine.FileExtensions = null;

            var instance = typeof(VirtualPathFactoryManager).GetProperty("Instance", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            LinkedList<IVirtualPathFactory> factories = (LinkedList<IVirtualPathFactory>)typeof(VirtualPathFactoryManager).GetField("_virtualPathFactories", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);
            factories.Clear();
            factories.AddLast(viewEngine);
        }

        private static void SetupT4MvcVirtualPathResolver()
        {
            var T4MVCHelpers = _applicationAssembly.GetTypes().Where(x => x.Name == "T4MVCHelpers").SingleOrDefault();
            if (T4MVCHelpers != null)
            {
                var ProcessVirtualPath = T4MVCHelpers.GetField("ProcessVirtualPath", BindingFlags.Public | BindingFlags.Static);
                if (ProcessVirtualPath != null)
                {
                    Func<string, string> resolver = path => path.Replace("~/", "/" + VirtualDirectory + "/");
                    ProcessVirtualPath.SetValue(null, resolver);
                }
            }
        }
    }
}