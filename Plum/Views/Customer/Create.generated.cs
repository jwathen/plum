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
    using Plum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Customer/Create.cshtml")]
    public partial class _Views_Customer_Create_cshtml : Plum.Web.ApplicationViewBase<Plum.ViewModels.Customer.CustomerViewModel>
    {
        public _Views_Customer_Create_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Customer\Create.cshtml"
   
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 6 "..\..\Views\Customer\Create.cshtml"
 using (Ajax.BeginForm(MVC.Customer.Create(), new AjaxOptions { OnBegin = "setLoading", OnComplete = "clearLoading", UpdateTargetId = "CreateCustomerModal" }))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"vertical-alignment-helper\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-dialog vertical-align-center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"modal-header\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" class=\"close\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-dismiss=\"modal\"");

WriteLiteral(">\r\n                        &times;\r\n                    </button>\r\n              " +
"      <h4");

WriteLiteral(" class=\"modal-title\"");

WriteLiteral(">\r\n                        Add Party to Wait List\r\n                    </h4>\r\n   " +
"             </div>\r\n                <fieldset>\r\n                    <div");

WriteLiteral(" class=\"modal-body\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 21 "..\..\Views\Customer\Create.cshtml"
                   Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 22 "..\..\Views\Customer\Create.cshtml"
                   Write(Html.EditorForModel());

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </fieldset>\r\n                <div");

WriteLiteral(" class=\"modal-footer\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-block btn-primary\"");

WriteLiteral(" value=\"Add Party\"");

WriteLiteral(" />\r\n                </div>\r\n");

WriteLiteral("                ");

            
            #line 28 "..\..\Views\Customer\Create.cshtml"
           Write(Html.HiddenFor(x => x.QueueId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Views\Customer\Create.cshtml"
           Write(Html.AntiForgeryToken2());

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 33 "..\..\Views\Customer\Create.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<script>clearLoading();</script>\r\n");

        }
    }
}
#pragma warning restore 1591
