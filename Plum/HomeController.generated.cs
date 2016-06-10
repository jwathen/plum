// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Plum.Controllers
{
    public partial class HomeController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected HomeController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController Actions { get { return MVC.Home; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Home";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Home";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string About = "About";
            public readonly string NotFound = "NotFound";
            public readonly string Error = "Error";
            public readonly string NotAuthorized = "NotAuthorized";
            public readonly string RemovedFromList = "RemovedFromList";
            public readonly string PrivacyPolicy = "PrivacyPolicy";
            public readonly string TermsOfUse = "TermsOfUse";
            public readonly string Manifest = "Manifest";
            public readonly string ContactUs = "ContactUs";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string About = "About";
            public const string NotFound = "NotFound";
            public const string Error = "Error";
            public const string NotAuthorized = "NotAuthorized";
            public const string RemovedFromList = "RemovedFromList";
            public const string PrivacyPolicy = "PrivacyPolicy";
            public const string TermsOfUse = "TermsOfUse";
            public const string Manifest = "Manifest";
            public const string ContactUs = "ContactUs";
        }


        static readonly ActionParamsClass_ContactUs s_params_ContactUs = new ActionParamsClass_ContactUs();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ContactUs ContactUsParams { get { return s_params_ContactUs; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ContactUs
        {
            public readonly string model = "model";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string About = "About";
                public readonly string ContactUs = "ContactUs";
                public readonly string Index = "Index";
                public readonly string NotAuthorized = "NotAuthorized";
                public readonly string NotFound = "NotFound";
                public readonly string PrivacyPolicy = "PrivacyPolicy";
                public readonly string RemovedFromList = "RemovedFromList";
                public readonly string TermsOfUse = "TermsOfUse";
            }
            public readonly string About = "~/Views/Home/About.cshtml";
            public readonly string ContactUs = "~/Views/Home/ContactUs.cshtml";
            public readonly string Index = "~/Views/Home/Index.cshtml";
            public readonly string NotAuthorized = "~/Views/Home/NotAuthorized.cshtml";
            public readonly string NotFound = "~/Views/Home/NotFound.cshtml";
            public readonly string PrivacyPolicy = "~/Views/Home/PrivacyPolicy.cshtml";
            public readonly string RemovedFromList = "~/Views/Home/RemovedFromList.cshtml";
            public readonly string TermsOfUse = "~/Views/Home/TermsOfUse.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_HomeController : Plum.Controllers.HomeController
    {
        public T4MVC_HomeController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index, "https");
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AboutOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult About()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.About, "https");
            AboutOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void NotFoundOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult NotFound()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.NotFound, "https");
            NotFoundOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ErrorOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Error()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Error, "https");
            ErrorOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void NotAuthorizedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult NotAuthorized()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.NotAuthorized, "https");
            NotAuthorizedOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void RemovedFromListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult RemovedFromList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemovedFromList, "https");
            RemovedFromListOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void PrivacyPolicyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult PrivacyPolicy()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PrivacyPolicy, "https");
            PrivacyPolicyOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void TermsOfUseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult TermsOfUse()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TermsOfUse, "https");
            TermsOfUseOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ManifestOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Manifest()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Manifest, "https");
            ManifestOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ContactUsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ContactUs()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ContactUs, "https");
            ContactUsOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ContactUsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Plum.ViewModels.Home.ContactUsViewModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult ContactUs(Plum.ViewModels.Home.ContactUsViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ContactUs, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ContactUsOverride(callInfo, model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
