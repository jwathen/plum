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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/EditorTemplates/CustomerViewModel.cshtml")]
    public partial class _Views_Shared_EditorTemplates_CustomerViewModel_cshtml_ : Plum.Web.ApplicationViewBase<Plum.ViewModels.Customer.CustomerViewModel>
    {
        public _Views_Shared_EditorTemplates_CustomerViewModel_cshtml_()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 4 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.LabelFor(x => x.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 5 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.TextBoxFor(x => x.Name, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 8 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.LabelFor(x => x.NumberInParty, "Number in Party"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 9 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.DropDownListFor(x => x.NumberInParty, new SelectList(Enumerable.Range(1, 40)), new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 12 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.LabelFor(x => x.PhoneNumber, "Phone Number (optional)"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 13 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.TextBoxFor(x => x.PhoneNumber, new { @class = "form-control", type = "tel" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591