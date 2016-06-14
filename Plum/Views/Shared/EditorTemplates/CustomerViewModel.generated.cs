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
            
            #line 3 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.HiddenFor(x => x.QueueId));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n        <p>\r\n            <i");

WriteLiteral(" class=\"fa fa-warning\"");

WriteLiteral("></i>\r\n            inform customer that msg and data rates may apply\r\n        </p" +
">\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteAttribute("for", Tuple.Create(" for=\"", 359), Tuple.Create("\"", 389)
            
            #line 13 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
, Tuple.Create(Tuple.Create("", 365), Tuple.Create<System.Object, System.Int32>(Html.IdFor(x => x.Name)
            
            #line default
            #line hidden
, 365), false)
);

WriteLiteral(">\r\n                Name\r\n                <span");

WriteLiteral(" class=\"text-danger\"");

WriteLiteral(">*</span>\r\n            </label>\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
       Write(Html.TextBoxFor(x => x.Name, new { @class = "form-control input-lg" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 22 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
       Write(Html.LabelFor(x => x.PhoneNumber, "Phone Number"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 23 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
       Write(Html.TextBoxFor(x => x.PhoneNumber, new { @class = "form-control input-lg", type = "tel", data_formatter = "phone" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <label");

WriteAttribute("for", Tuple.Create(" for=\"", 995), Tuple.Create("\"", 1034)
            
            #line 30 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
, Tuple.Create(Tuple.Create("", 1001), Tuple.Create<System.Object, System.Int32>(Html.IdFor(x => x.NumberInParty)
            
            #line default
            #line hidden
, 1001), false)
);

WriteLiteral(">\r\n                Number in Party\r\n            </label>\r\n");

WriteLiteral("            ");

            
            #line 33 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
       Write(Html.DropDownListFor(x => x.NumberInParty, new SelectList(Enumerable.Range(1, 40)), new { @class = "form-control input-lg" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 38 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
       Write(Html.LabelFor(x => x.QuotedTimeInMinutes, "Quoted Wait Time"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 39 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
       Write(Html.DropDownListFor(x => x.QuotedTimeInMinutes, Model.GetQuotedWaitTimeOptions(), "None", new { @class = "form-control input-lg" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 44 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.LabelFor(x => x.Note));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 45 "..\..\Views\Shared\EditorTemplates\CustomerViewModel.cshtml"
Write(Html.TextBoxFor(x => x.Note, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>");

        }
    }
}
#pragma warning restore 1591
