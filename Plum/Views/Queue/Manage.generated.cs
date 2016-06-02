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
    
    #line 2 "..\..\Views\Queue\Manage.cshtml"
    using Plum.ViewModels.Customer;
    
    #line default
    #line hidden
    using Plum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Queue/Manage.cshtml")]
    public partial class _Views_Queue_Manage_cshtml : Plum.Web.ApplicationViewBase<Plum.Models.Queue>
    {
        public _Views_Queue_Manage_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Queue\Manage.cshtml"
  
    ViewBag.Title = "Manage";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <h3>");

            
            #line 7 "..\..\Views\Queue\Manage.cshtml"
   Write(Model.Business.Name);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n    <button");

WriteLiteral(" class=\"btn btn-block btn-primary\"");

WriteLiteral(" data-toggle=\"modal\"");

WriteLiteral(" data-target=\"#AddCustomerModal\"");

WriteLiteral(">\r\n        <i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>\r\n        Add Party\r\n    </button>\r\n    <br />\r\n");

            
            #line 13 "..\..\Views\Queue\Manage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Queue\Manage.cshtml"
     if (Model.Customers.Count == 0)
    {

            
            #line default
            #line hidden
WriteLiteral("        <p>\r\n            There are no customers waiting.\r\n        </p>\r\n");

            
            #line 18 "..\..\Views\Queue\Manage.cshtml"
    }
    else if (Model.Customers.Count > 1)
    {

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" class=\"text-muted\"");

WriteLiteral(">\r\n            You can rearrange this list by dragging parties.\r\n        </p>\r\n");

            
            #line 24 "..\..\Views\Queue\Manage.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    <ul");

WriteLiteral(" class=\"list-group text-center\"");

WriteLiteral(">\r\n");

            
            #line 26 "..\..\Views\Queue\Manage.cshtml"
        
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Queue\Manage.cshtml"
         foreach (var customer in Model.OrderedCustomers())
        {

            
            #line default
            #line hidden
WriteLiteral("            <li");

WriteLiteral(" class=\"list-group-item\"");

WriteLiteral(" data-manage-customer-id=\"");

            
            #line 28 "..\..\Views\Queue\Manage.cshtml"
                                                            Write(customer.Id);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Views\Queue\Manage.cshtml"
           Write(customer.Name);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 29 "..\..\Views\Queue\Manage.cshtml"
                           Write(customer.NumberInParty);

            
            #line default
            #line hidden
WriteLiteral(") Waited ");

            
            #line 29 "..\..\Views\Queue\Manage.cshtml"
                                                           Write(customer.TimeWaited().Humanize());

            
            #line default
            #line hidden
WriteLiteral("\r\n            </li>\r\n");

            
            #line 31 "..\..\Views\Queue\Manage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n</div>\r\n<div");

WriteLiteral(" id=\"ManageCustomerModal\"");

WriteLiteral(" class=\"modal\"");

WriteLiteral(">\r\n</div>\r\n<div");

WriteLiteral(" id=\"AddCustomerModal\"");

WriteLiteral(" class=\"modal\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 37 "..\..\Views\Queue\Manage.cshtml"
Write(Html.Partial(MVC.Queue.Views.AddCustomerModal, new CustomerViewModel { QueueId = Model.Id }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script>\r\n        window.viewData = {};\r\n        window.viewData.manageCust" +
"omerModalUrl = \'");

            
            #line 42 "..\..\Views\Queue\Manage.cshtml"
                                             Write(Url.Action(MVC.Queue.ManageCustomerModal()));

            
            #line default
            #line hidden
WriteLiteral("\';\r\n    </script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1361), Tuple.Create("\"", 1434)
            
            #line 44 "..\..\Views\Queue\Manage.cshtml"
, Tuple.Create(Tuple.Create("", 1367), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Scripts.Queue.Manage_es5_min_js)
            
            #line default
            #line hidden
, 1367), false)
);

WriteLiteral("></script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
