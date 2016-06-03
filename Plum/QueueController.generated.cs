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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CustomerView()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CustomerView, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CancelPlaceInLine()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CancelPlaceInLine, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Manage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Manage, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ManageCustomerModal()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ManageCustomerModal, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> RemoveCustomer()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveCustomer, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddCustomer()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddCustomer, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SendReadyTextMessage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SendReadyTextMessage, "https");
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MoveToEndOfList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MoveToEndOfList, "https");
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
            public readonly string CustomerView = "CustomerView";
            public readonly string CancelPlaceInLine = "CancelPlaceInLine";
            public readonly string Manage = "Manage";
            public readonly string ManageCustomerModal = "ManageCustomerModal";
            public readonly string RemoveCustomer = "RemoveCustomer";
            public readonly string AddCustomer = "AddCustomer";
            public readonly string SendReadyTextMessage = "SendReadyTextMessage";
            public readonly string MoveToEndOfList = "MoveToEndOfList";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string CustomerView = "CustomerView";
            public const string CancelPlaceInLine = "CancelPlaceInLine";
            public const string Manage = "Manage";
            public const string ManageCustomerModal = "ManageCustomerModal";
            public const string RemoveCustomer = "RemoveCustomer";
            public const string AddCustomer = "AddCustomer";
            public const string SendReadyTextMessage = "SendReadyTextMessage";
            public const string MoveToEndOfList = "MoveToEndOfList";
        }


        static readonly ActionParamsClass_CustomerView s_params_CustomerView = new ActionParamsClass_CustomerView();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CustomerView CustomerViewParams { get { return s_params_CustomerView; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CustomerView
        {
            public readonly string urlToken = "urlToken";
        }
        static readonly ActionParamsClass_CancelPlaceInLine s_params_CancelPlaceInLine = new ActionParamsClass_CancelPlaceInLine();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CancelPlaceInLine CancelPlaceInLineParams { get { return s_params_CancelPlaceInLine; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CancelPlaceInLine
        {
            public readonly string urlToken = "urlToken";
        }
        static readonly ActionParamsClass_Manage s_params_Manage = new ActionParamsClass_Manage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Manage ManageParams { get { return s_params_Manage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Manage
        {
            public readonly string queueId = "queueId";
        }
        static readonly ActionParamsClass_ManageCustomerModal s_params_ManageCustomerModal = new ActionParamsClass_ManageCustomerModal();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ManageCustomerModal ManageCustomerModalParams { get { return s_params_ManageCustomerModal; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ManageCustomerModal
        {
            public readonly string customerId = "customerId";
        }
        static readonly ActionParamsClass_RemoveCustomer s_params_RemoveCustomer = new ActionParamsClass_RemoveCustomer();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RemoveCustomer RemoveCustomerParams { get { return s_params_RemoveCustomer; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RemoveCustomer
        {
            public readonly string customerId = "customerId";
        }
        static readonly ActionParamsClass_AddCustomer s_params_AddCustomer = new ActionParamsClass_AddCustomer();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddCustomer AddCustomerParams { get { return s_params_AddCustomer; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddCustomer
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_SendReadyTextMessage s_params_SendReadyTextMessage = new ActionParamsClass_SendReadyTextMessage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SendReadyTextMessage SendReadyTextMessageParams { get { return s_params_SendReadyTextMessage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SendReadyTextMessage
        {
            public readonly string customerId = "customerId";
        }
        static readonly ActionParamsClass_MoveToEndOfList s_params_MoveToEndOfList = new ActionParamsClass_MoveToEndOfList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_MoveToEndOfList MoveToEndOfListParams { get { return s_params_MoveToEndOfList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_MoveToEndOfList
        {
            public readonly string customerId = "customerId";
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
                public readonly string AddCustomerModal = "AddCustomerModal";
                public readonly string CustomerNotFound = "CustomerNotFound";
                public readonly string CustomerView = "CustomerView";
                public readonly string Manage = "Manage";
                public readonly string ManageCustomerModal = "ManageCustomerModal";
            }
            public readonly string AddCustomerModal = "~/Views/Queue/AddCustomerModal.cshtml";
            public readonly string CustomerNotFound = "~/Views/Queue/CustomerNotFound.cshtml";
            public readonly string CustomerView = "~/Views/Queue/CustomerView.cshtml";
            public readonly string Manage = "~/Views/Queue/Manage.cshtml";
            public readonly string ManageCustomerModal = "~/Views/Queue/ManageCustomerModal.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_QueueController : Plum.Controllers.QueueController
    {
        public T4MVC_QueueController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CustomerViewOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string urlToken);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CustomerView(string urlToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CustomerView, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "urlToken", urlToken);
            CustomerViewOverride(callInfo, urlToken);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void CancelPlaceInLineOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string urlToken);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CancelPlaceInLine(string urlToken)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CancelPlaceInLine, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "urlToken", urlToken);
            CancelPlaceInLineOverride(callInfo, urlToken);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ManageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? queueId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Manage(int? queueId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Manage, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "queueId", queueId);
            ManageOverride(callInfo, queueId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ManageCustomerModalOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int customerId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ManageCustomerModal(int customerId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ManageCustomerModal, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "customerId", customerId);
            ManageCustomerModalOverride(callInfo, customerId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void RemoveCustomerOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int customerId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> RemoveCustomer(int customerId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveCustomer, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "customerId", customerId);
            RemoveCustomerOverride(callInfo, customerId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void AddCustomerOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Plum.ViewModels.Customer.CustomerViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddCustomer(Plum.ViewModels.Customer.CustomerViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddCustomer, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            AddCustomerOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void SendReadyTextMessageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int customerId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SendReadyTextMessage(int customerId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SendReadyTextMessage, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "customerId", customerId);
            SendReadyTextMessageOverride(callInfo, customerId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void MoveToEndOfListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int customerId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> MoveToEndOfList(int customerId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.MoveToEndOfList, "https");
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "customerId", customerId);
            MoveToEndOfListOverride(callInfo, customerId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
