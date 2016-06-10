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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/ContactUs.cshtml")]
    public partial class _Views_Home_ContactUs_cshtml : Plum.Web.ApplicationViewBase<Plum.ViewModels.Home.ContactUsViewModel>
    {
        public _Views_Home_ContactUs_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Home\ContactUs.cshtml"
  
    ViewBag.Title = "Contact Us";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral(">\r\n            <h2>Contact Us</h2>\r\n");

WriteLiteral("            ");

            
            #line 9 "..\..\Views\Home\ContactUs.cshtml"
       Write(Html.FlashMessage());

            
            #line default
            #line hidden
WriteLiteral("\r\n            <form");

WriteAttribute("action", Tuple.Create(" action=\"", 254), Tuple.Create("\"", 296)
            
            #line 10 "..\..\Views\Home\ContactUs.cshtml"
, Tuple.Create(Tuple.Create("", 263), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Home.ContactUs())
            
            #line default
            #line hidden
, 263), false)
);

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 11 "..\..\Views\Home\ContactUs.cshtml"
           Write(Html.ValidationSummary());

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteAttribute("for", Tuple.Create(" for=\"", 425), Tuple.Create("\"", 463)
            
            #line 13 "..\..\Views\Home\ContactUs.cshtml"
, Tuple.Create(Tuple.Create("", 431), Tuple.Create<System.Object, System.Int32>(Html.IdFor(x => x.EmailAddress)
            
            #line default
            #line hidden
, 431), false)
);

WriteLiteral(">\r\n                        Your Email Address\r\n                        <span");

WriteLiteral(" class=\"text-danger\"");

WriteLiteral(">*</span>\r\n                    </label>\r\n");

WriteLiteral("                    ");

            
            #line 17 "..\..\Views\Home\ContactUs.cshtml"
               Write(Html.TextBoxFor(x => x.EmailAddress, new { @class = "form-control", type = "email" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label");

WriteAttribute("for", Tuple.Create(" for=\"", 801), Tuple.Create("\"", 834)
            
            #line 20 "..\..\Views\Home\ContactUs.cshtml"
, Tuple.Create(Tuple.Create("", 807), Tuple.Create<System.Object, System.Int32>(Html.IdFor(x => x.Message)
            
            #line default
            #line hidden
, 807), false)
);

WriteLiteral(">\r\n                        Message\r\n                        <span");

WriteLiteral(" class=\"text-danger\"");

WriteLiteral(">*</span>\r\n                    </label>\r\n");

WriteLiteral("                    ");

            
            #line 24 "..\..\Views\Home\ContactUs.cshtml"
               Write(Html.TextAreaFor(x => x.Message, new { @class = "form-control", rows = 8 }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Send Message\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" />\r\n");

WriteLiteral("                ");

            
            #line 27 "..\..\Views\Home\ContactUs.cshtml"
           Write(Html.AntiForgeryToken2());

            
            #line default
            #line hidden
WriteLiteral("\r\n            </form>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1300), Tuple.Create("\"", 1375)
            
            #line 33 "..\..\Views\Home\ContactUs.cshtml"
, Tuple.Create(Tuple.Create("", 1306), Tuple.Create<System.Object, System.Int32>(Html.FileVersionUrl(Links.Content.Scripts.Home.ContactUs_es5_min_js)
            
            #line default
            #line hidden
, 1306), false)
);

WriteLiteral("></script>\r\n");

});

        }
    }
}
#pragma warning restore 1591