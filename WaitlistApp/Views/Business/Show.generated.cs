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
    using WaitlistApp;
    using WaitlistApp.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Business/Show.cshtml")]
    public partial class _Views_Business_Show_cshtml : WaitlistApp.Web.ApplicationViewBase<WaitlistApp.ViewModels.Business.ShowViewModel>
    {
        public _Views_Business_Show_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Business\Show.cshtml"
  
    ViewBag.Title = "Settings";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 191), Tuple.Create("\"", 240)
            
            #line 9 "..\..\Views\Business\Show.cshtml"
, Tuple.Create(Tuple.Create("", 198), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Queue.Show(Model.QueueId))
            
            #line default
            #line hidden
, 198), false)
);

WriteLiteral(" class=\"btn btn-primary btn-lg pull-right\"");

WriteLiteral(" data-loading-overlay=\"true\"");

WriteLiteral(">\r\n                Go To Wait List\r\n            </a>\r\n            <h2");

WriteLiteral(" class=\"pull-left\"");

WriteLiteral(">Settings</h2>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    Business Information (your customers will see this)\r\n     " +
"           </div>\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" id=\"BusinessInformationPanel\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 22 "..\..\Views\Business\Show.cshtml"
               Write(Html.DisplayFor(x => x.BusinessInformation));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    Sign In Information\r\n                </div>\r\n             " +
"   <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" id=\"SignInInformationPanel\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\Business\Show.cshtml"
               Write(Html.DisplayFor(x => x.SignInInformation));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <di" +
"v");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    Text Messages\r\n                </div>\r\n                <di" +
"v");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" id=\"TextMessagesPanel\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 44 "..\..\Views\Business\Show.cshtml"
               Write(Html.DisplayFor(x => x.TextMessages));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r" +
"\n\r\n");

        }
    }
}
#pragma warning restore 1591