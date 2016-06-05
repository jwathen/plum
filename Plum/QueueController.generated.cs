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
    public partial class QueueController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public QueueController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected QueueController(Dummy d) { }

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

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ShowCustomer()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ShowCustomer, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CustomerViewQueueList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CustomerViewQueueList, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Show()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Show, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> BusinessViewQueueList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.BusinessViewQueueList, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Sort()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Sort, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public QueueController Actions { get { return MVC.Queue; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Queue";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Queue";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ShowCustomer = "ShowCustomer";
            public readonly string CustomerViewQueueList = "CustomerViewQueueList";
            public readonly string Show = "Show";
            public readonly string BusinessViewQueueList = "BusinessViewQueueList";
            public readonly string Sort = "Sort";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ShowCustomer = "ShowCustomer";
            public const string CustomerViewQueueList = "CustomerViewQueueList";
            public const string Show = "Show";
            public const string BusinessViewQueueList = "BusinessViewQueueList";
            public const string Sort = "Sort";
        }


        static readonly ActionParamsClass_ShowCustomer s_params_ShowCustomer = new ActionParamsClass_ShowCustomer();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ShowCustomer ShowCustomerParams { get { return s_params_ShowCustomer; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ShowCustomer
        {
            public readonly string urlToken = "urlToken";
        }
        static readonly ActionParamsClass_CustomerViewQueueList s_params_CustomerViewQueueList = new ActionParamsClass_CustomerViewQueueList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CustomerViewQueueList CustomerViewQueueListParams { get { return s_params_CustomerViewQueueList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CustomerViewQueueList
        {
            public readonly string urlToken = "urlToken";
        }
        static readonly ActionParamsClass_Show s_params_Show = new ActionParamsClass_Show();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Show ShowParams { get { return s_params_Show; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Show
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_BusinessViewQueueList s_params_BusinessViewQueueList = new ActionParamsClass_BusinessViewQueueList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_BusinessViewQueueList BusinessViewQueueListParams { get { return s_params_BusinessViewQueueList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_BusinessViewQueueList
        {
            public readonly string queueId = "queueId";
        }
        static readonly ActionParamsClass_Sort s_params_Sort = new ActionParamsClass_Sort();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Sort SortParams { get { return s_params_Sort; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Sort
        {
            public readonly string id = "id";
            public readonly string customerIds = "customerIds";
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
                public readonly string BusinessViewQueueList = "BusinessViewQueueList";
                public readonly string CustomerNotFound = "CustomerNotFound";
                public readonly string CustomerViewQueueList = "CustomerViewQueueList";
                public readonly string Show = "Show";
                public readonly string ShowCustomer = "ShowCustomer";
            }
            public readonly string BusinessViewQueueList = "~/Views/Queue/BusinessViewQueueList.cshtml";
            public readonly string CustomerNotFound = "~/Views/Queue/CustomerNotFound.cshtml";
            public readonly string CustomerViewQueueList = "~/Views/Queue/CustomerViewQueueList.cshtml";
            public readonly string Show = "~/Views/Queue/Show.cshtml";
            public readonly string ShowCustomer = "~/Views/Queue/ShowCustomer.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_QueueController : Plum.Controllers.QueueController
    {
        public T4MVC_QueueController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ShowCustomerOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string urlToken);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ShowCustomer(string urlToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ShowCustomer, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "urlToken", urlToken);
            ShowCustomerOverride(callInfo, urlToken);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void CustomerViewQueueListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string urlToken);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CustomerViewQueueList(string urlToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CustomerViewQueueList, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "urlToken", urlToken);
            CustomerViewQueueListOverride(callInfo, urlToken);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ShowOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Show(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Show, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ShowOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void BusinessViewQueueListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? queueId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> BusinessViewQueueList(int? queueId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.BusinessViewQueueList, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "queueId", queueId);
            BusinessViewQueueListOverride(callInfo, queueId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void SortOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, int[] customerIds);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Sort(int id, int[] customerIds)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Sort, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "customerIds", customerIds);
            SortOverride(callInfo, id, customerIds);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
