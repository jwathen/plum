﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Humanizer;
    using Plum;
    
    #line 2 "..\..\Views\Queue\Show.cshtml"
    using Plum.ViewModels.Customer;
    
    #line default
    #line hidden
    using Plum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Queue/Show.cshtml")]
    public partial class _Views_Queue_Show_cshtml : Plum.Web.ApplicationViewBase<Plum.Models.Queue>
    {
        public _Views_Queue_Show_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Queue\Show.cshtml"
  
    ViewBag.Title = "Wait List";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <h2>");

            
            #line 9 "..\..\Views\Queue\Show.cshtml"
           Write(Model.Business.Name);

            
            #line default
            #line hidden
WriteLiteral("</h2>            \r\n");

WriteLiteral("            ");

            
            #line 10 "..\..\Views\Queue\Show.cshtml"
       Write(Html.FlashMessage());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <p");

WriteLiteral(" class=\"hidden-md hidden-lg\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn btn-block btn-primary\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#CreateCustomerModal\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>\r\n                    Add Party\r\n                </button>\r\n                " +
"<a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"btn btn-block btn-default\"");

WriteLiteral(" data-command=\"rearrange\"");

WriteAttribute("style", Tuple.Create(" style=\"", 706), Tuple.Create("\"", 767)
            
            #line 20 "..\..\Views\Queue\Show.cshtml"
                , Tuple.Create(Tuple.Create("", 714), Tuple.Create<System.Object, System.Int32>(Model.Customers.Count < 2 ? "display:none;" : null
            
            #line default
            #line hidden
, 714), false)
);

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-list\"");

WriteLiteral("></i>\r\n                    <span>Reorder List</span>\r\n                </a>\r\n     " +
"       </p>\r\n            <p");

WriteLiteral(" class=\"hidden-sm hidden-xs\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#CreateCustomerModal\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>\r\n                    Add Party\r\n                </button>\r\n                " +
"<button");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" data-command=\"rearrange\"");

WriteAttribute("style", Tuple.Create(" style=\"", 1234), Tuple.Create("\"", 1295)
            
            #line 30 "..\..\Views\Queue\Show.cshtml"
 , Tuple.Create(Tuple.Create("", 1242), Tuple.Create<System.Object, System.Int32>(Model.Customers.Count < 2 ? "display:none;" : null
            
            #line default
            #line hidden
, 1242), false)
);

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-list\"");

WriteLiteral("></i>\r\n                    <span>Reorder List</span>\r\n                </button>\r\n" +
"            </p>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"businessViewQueueList\"");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Views\Queue\Show.cshtml"
       Write(Html.Partial(MVC.Queue.Views.BusinessViewQueueList, Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" id=\"ShowCustomerModal\"");

WriteLiteral(" class=\"modal\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"CreateCustomerModal\"");

WriteLiteral(" class=\"modal\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 46 "..\..\Views\Queue\Show.cshtml"
Write(Html.Partial(MVC.Customer.Views.Create, new CustomerViewModel { QueueId = Model.Id }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script>\r\n        window.viewData = {};\r\n        window.viewData.queueId = " +
"");

            
            #line 52 "..\..\Views\Queue\Show.cshtml"
                             Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral(";\r\n        window.viewData.sortingDebounce = 500;\r\n        window.viewData.sortQu" +
"eueUrl = \'");

            
            #line 54 "..\..\Views\Queue\Show.cshtml"
                                   Write(Url.Action(MVC.Queue.Sort()));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        window.viewData.udpateBusinessViewQueueListUrl = \'");

            
            #line 55 "..\..\Views\Queue\Show.cshtml"
                                                     Write(Url.Action(MVC.Queue.BusinessViewQueueList()));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n        window.viewData.showCustomerUrl = \'/customer\';\r\n    </script>\r\n    <s" +
"cript");

WriteAttribute("src", Tuple.Create(" src=\"", 2281), Tuple.Create("\"", 2352)
            
            #line 58 "..\..\Views\Queue\Show.cshtml"
, Tuple.Create(Tuple.Create("", 2287), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Scripts.Queue.Show_es5_min_js)
            
            #line default
            #line hidden
, 2287), false)
);

WriteLiteral("></script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
