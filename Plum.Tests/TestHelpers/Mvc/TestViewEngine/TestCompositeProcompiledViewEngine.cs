using RazorGenerator.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Plum.Tests.TestHelpers.Mvc.TestViewEngine
{
    public class TestCompositePrecompiledMvcEngine : VirtualPathProviderViewEngine, IVirtualPathFactory
    {
        private readonly IDictionary<string, ViewMapping> _mappings
            = new Dictionary<string, ViewMapping>(StringComparer.OrdinalIgnoreCase);
        private readonly IViewPageActivator _viewPageActivator;

        public TestCompositePrecompiledMvcEngine(params PrecompiledViewAssembly[] viewAssemblies)
            : this(viewAssemblies, null)
        {
        }

        public TestCompositePrecompiledMvcEngine(IEnumerable<PrecompiledViewAssembly> viewAssemblies, IViewPageActivator viewPageActivator)
        {
            base.AreaViewLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
            };

            base.AreaMasterLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
            };

            base.AreaPartialViewLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
            };
            base.ViewLocationFormats = new[] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
            };
            base.MasterLocationFormats = new[] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
            };
            base.PartialViewLocationFormats = new[] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
            };
            base.FileExtensions = null;

            foreach (var viewAssembly in viewAssemblies)
            {
                if (viewAssembly.UsePhysicalViewsIfNewer)
                {
                    throw new NotSupportedException("UsePhysicalViewsIfNewer is not supported while testing.");
                }
                foreach (var mapping in viewAssembly.GetTypeMappings())
                {
                    _mappings[mapping.Key] = new ViewMapping { Type = mapping.Value, ViewAssembly = viewAssembly };
                }
            }

            _viewPageActivator = viewPageActivator
                ?? DependencyResolver.Current.GetService<IViewPageActivator>() /* For compatibility, remove this line within next version */
                ?? DefaultViewPageActivator.Current;
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            virtualPath = EnsureVirtualPathPrefix(virtualPath);

            ViewMapping mapping;
            if (!_mappings.TryGetValue(virtualPath, out mapping))
            {
                return false;
            }

            return Exists(virtualPath);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            partialPath = EnsureVirtualPathPrefix(partialPath);

            return CreateViewInternal(partialPath, masterPath: null, runViewStartPages: false);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            viewPath = EnsureVirtualPathPrefix(viewPath);

            return CreateViewInternal(viewPath, masterPath, runViewStartPages: true);
        }

        private IView CreateViewInternal(string viewPath, string masterPath, bool runViewStartPages)
        {
            ViewMapping mapping;
            if (_mappings.TryGetValue(viewPath, out mapping))
            {
                return new TestPrecompiledMvcView(viewPath, masterPath, mapping.Type, runViewStartPages, base.FileExtensions, _viewPageActivator);
            }
            return null;
        }

        public object CreateInstance(string virtualPath)
        {
            virtualPath = EnsureVirtualPathPrefix(virtualPath);

            ViewMapping mapping;

            if (!_mappings.TryGetValue(virtualPath, out mapping))
            {
                return null;
            }

            return _viewPageActivator.Create((ControllerContext)null, mapping.Type);
        }

        internal static string EnsureVirtualPathPrefix(string virtualPath)
        {
            if (!String.IsNullOrEmpty(virtualPath))
            {
                // For a virtual path lookups to succeed, it needs to start with a ~/.
                if (!virtualPath.StartsWith("~/", StringComparison.Ordinal))
                {
                    virtualPath = "~/" + virtualPath.TrimStart(new[] { '/', '~' });
                }
            }
            return virtualPath;
        }

        public bool Exists(string virtualPath)
        {
            virtualPath = EnsureVirtualPathPrefix(virtualPath);

            return _mappings.ContainsKey(virtualPath);
        }

        private struct ViewMapping
        {
            public Type Type { get; set; }
            public PrecompiledViewAssembly ViewAssembly { get; set; }
        }
    }
}
